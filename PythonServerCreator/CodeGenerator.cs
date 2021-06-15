using PythonServerCreator.Declaration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PythonServerCreator
{
    class CodeGenerator
    {
        public readonly string functionTemplatePath = "GeneratedServer/framework/command_template.py";
        public readonly string functionHandlerTemplatePath = "GeneratedServer/framework/command_handler_template.py";
        public readonly string generatedHandlersPath = "GeneratedServer/server/command_handlers";
        public readonly string generatedClientFunctionsPath = "GeneratedServer/client";

        private readonly string functionNameFiller = "FUNCTION_NAME";
        private readonly string stringedFunctionNameFiller = "STRINGED_FUNCTION_NAME";
        private readonly string functionParamsFiller = "FUNCTION_PARAMS";
        private readonly string filledFunctionsParamsList = "FILLED_FUNCTION_PARAMS_LIST";
        private readonly string functionReturnTypeFiller = "FUNCTION_RETURN_TYPE";
        private readonly string hostnameParameter = "HOSTNAME";
        private readonly string portParameter = "PORT";

        private readonly List<string> _filesCopied;

        private readonly FunctionDeclaration[] _functionDeclarations;
        private readonly Dictionary<string, string> _typeMap;
        private readonly IPEndPoint _ipEndPoint;

        public CodeGenerator(FunctionDeclaration[] functionDeclarations,
            Dictionary<string, string> typeMap,
            IPEndPoint ipEndPoint)
        {
            _functionDeclarations = functionDeclarations;
            _typeMap = typeMap;
            _filesCopied = new List<string>();
            _ipEndPoint = ipEndPoint;
        }

        public void GenerateServer(string sourceFrameworkPath, string destFrameworkPath)
        {
            RecursiveCopyStructure(sourceFrameworkPath, destFrameworkPath);
            WriteHandlerFiles(GenerateFunctionHandlers());
            WriteClientFunctionFiles(GenerateClientFunctions());
            InsertHostnameAndPort();
        }

        private void RecursiveCopyStructure(string source, string dest)
        {
            foreach (string directory in Directory.GetDirectories(source))
            {
                string directoryName = Path.GetFileName(directory);
                if (directoryName == ".idea" || directoryName == "__pycache__") continue;


                string destDirectoryPath = Path.Combine(dest, directoryName);
                if (Directory.Exists(destDirectoryPath))
                    Directory.Delete(destDirectoryPath, true);

                Directory.CreateDirectory(destDirectoryPath);
                CopyFiles(directory, destDirectoryPath);
                RecursiveCopyStructure(directory, destDirectoryPath);
            }
        }

        private void CopyFiles(string sourceDir, string destDir)
        {
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFilePath = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFilePath);
                _filesCopied.Add(destFilePath);
            }
        }

        private Dictionary<FunctionDeclaration, string> GenerateFunctionHandlers()
        {
            Dictionary<FunctionDeclaration, string> functionHandlerCodes = new Dictionary<FunctionDeclaration, string>();
            foreach (FunctionDeclaration functionDeclaration in _functionDeclarations)
            {
                string functionHandlerTemplateCode = File.ReadAllText(functionHandlerTemplatePath);
                functionHandlerTemplateCode = functionHandlerTemplateCode.Replace(EncapsulateAsParameter(stringedFunctionNameFiller), $"\"{functionDeclaration.FunctionName}\"");
                functionHandlerTemplateCode = functionHandlerTemplateCode.Replace(EncapsulateAsParameter(functionNameFiller), ToTitleString(functionDeclaration.FunctionName));

                string generatedPythonicFunctionParams = GeneratePythonFunctionParameters(functionDeclaration);
                functionHandlerTemplateCode = functionHandlerTemplateCode.Replace(EncapsulateAsParameter(functionParamsFiller), generatedPythonicFunctionParams);
                functionHandlerTemplateCode = functionHandlerTemplateCode.Replace(EncapsulateAsParameter(functionReturnTypeFiller), _typeMap[functionDeclaration.ReturnType]);

                functionHandlerCodes[functionDeclaration] = functionHandlerTemplateCode;
            }
            return functionHandlerCodes;
        }

        private Dictionary<FunctionDeclaration, string> GenerateClientFunctions()
        {
            Dictionary<FunctionDeclaration, string> functionClientCodes = new Dictionary<FunctionDeclaration, string>();
            foreach (FunctionDeclaration functionDeclaration in _functionDeclarations)
            {
                string functionTemplateCode = File.ReadAllText(functionTemplatePath);
                functionTemplateCode = functionTemplateCode.Replace(EncapsulateAsParameter(stringedFunctionNameFiller), $"\"{functionDeclaration.FunctionName}\"");
                functionTemplateCode = functionTemplateCode.Replace(EncapsulateAsParameter(functionNameFiller), ToTitleString(functionDeclaration.FunctionName));

                string generatedFilledParamsList = GenerateFilledParamsList(functionDeclaration);
                functionTemplateCode = functionTemplateCode.Replace(EncapsulateAsParameter(filledFunctionsParamsList), generatedFilledParamsList);

                string generatedPythonicFunctionParams = GeneratePythonFunctionParameters(functionDeclaration);
                functionTemplateCode = functionTemplateCode.Replace(EncapsulateAsParameter(functionParamsFiller), generatedPythonicFunctionParams);                

                functionClientCodes[functionDeclaration] = functionTemplateCode;
            }
            return functionClientCodes;
        }

        private string GeneratePythonFunctionParameters(FunctionDeclaration functionDeclaration)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int count = 0;
            foreach (FunctionParameter parameter in functionDeclaration.FunctionParameters)
            {
                count++;
                string pythonicDeclaration = parameter.ToPythonicDeclaration(_typeMap);
                if (count == functionDeclaration.FunctionParameters.Length)
                    stringBuilder.Append(pythonicDeclaration);
                else
                    stringBuilder.Append($"{parameter.ToPythonicDeclaration(_typeMap)}, ");
            }
            return stringBuilder.ToString();
        }

        private string GenerateFilledParamsList(FunctionDeclaration functionDeclaration)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (FunctionParameter parameter in functionDeclaration.FunctionParameters)
            {
                stringBuilder.Append($"{parameter.ParameterName}, ");
            }
            return stringBuilder.ToString();
        }

        private void WriteHandlerFiles(Dictionary<FunctionDeclaration, string> generatedHandlers)
        {
            foreach (FunctionDeclaration functionDeclaration in generatedHandlers.Keys)
            {
                string generatedHandlerCode = generatedHandlers[functionDeclaration];

                if (! Directory.Exists(generatedHandlersPath))
                {
                    Directory.CreateDirectory(generatedHandlersPath);
                }

                File.WriteAllText(Path.Combine(generatedHandlersPath, $"{functionDeclaration.FunctionName}_handler.py"), generatedHandlerCode);
            }
        }

        private void WriteClientFunctionFiles(Dictionary<FunctionDeclaration, string> generatedClientFunctions)
        {
            using (FileStream functionsFile = File.Open(Path.Combine(generatedClientFunctionsPath, "functions.py"), FileMode.Append))
            {
                bool isFirstFunction = true;
                foreach (FunctionDeclaration functionDeclaration in generatedClientFunctions.Keys)
                {
                    string generatedClientFunctionCode;
                    if (isFirstFunction)
                    {
                        generatedClientFunctionCode = generatedClientFunctions[functionDeclaration] + "\n\n";
                        isFirstFunction = false;
                    }
                    else
                    {
                        generatedClientFunctionCode = OnlyTakeClassDefinitionFromCode(generatedClientFunctions[functionDeclaration]) + "\n\n";
                    }
                    byte[] codeAsBytes = Encoding.UTF8.GetBytes(generatedClientFunctionCode);
                    functionsFile.Write(codeAsBytes);                    
                }
            }
        }

        private void InsertHostnameAndPort()
        {
            foreach (string filePath in _filesCopied)
            {
                string code = File.ReadAllText(filePath);
                code = code.Replace(EncapsulateAsParameter(hostnameParameter), $"'{_ipEndPoint.Address.ToString()}'");
                code = code.Replace(EncapsulateAsParameter(portParameter), _ipEndPoint.Port.ToString());
                File.WriteAllText(filePath, code);
            }
        }

        private string ToTitleString(string s)
        {
            string finalString = "";
            int count = 0;
            string[] slices = s.Split('_');
            foreach (string slice in slices)
            {
                count++;
                char[] vs = slice.ToCharArray();
                vs[0] = slice[0].ToString().ToUpper()[0];
                if (count == slices.Length)
                    finalString += new string(vs);
                else
                    finalString += new string(vs) + "_";
            }
            return finalString;
        }

        private string OnlyTakeClassDefinitionFromCode(string code)
        {
            string[] lines = code.Replace("\r", "").Split('\n');

            StringBuilder stringBuilder = new StringBuilder();
            bool functionClassDefinitionStarted = false;
            foreach (string line in lines)
            {
                if (line.StartsWith("class"))
                    functionClassDefinitionStarted = true;
                if (functionClassDefinitionStarted)
                    stringBuilder.Append(line + '\n');
            }

            return stringBuilder.ToString();
        }

        private string EncapsulateAsParameter(string templateParameter)
        {
            return $"$({templateParameter})";
        }
    }
}
