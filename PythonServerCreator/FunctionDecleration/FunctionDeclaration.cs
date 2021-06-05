using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PythonServerCreator.Declaration
{
    class FunctionDeclaration
    {                        
        public FunctionDeclaration(string functionName, string returnType, FunctionParameter[] functionParameters)
        {
            FunctionName = functionName;
            ReturnType = returnType;
            FunctionParameters = functionParameters;
        }

        public string FunctionName { get; }
        public string ReturnType { get; }
        public FunctionParameter[] FunctionParameters { get; }

        public override string ToString()
        {
            string parameters = "";
            for (int i = 0; i < FunctionParameters.Length; i++)
            {
                if (i != FunctionParameters.Length - 1)
                    parameters += $"{FunctionParameters[i].ParameterType} {FunctionParameters[i].ParameterName}, ";
                else
                    parameters += $"{FunctionParameters[i].ParameterType} {FunctionParameters[i].ParameterName}";
            }
            return $"{ReturnType} {FunctionName}({parameters})";
        }
    }
}
