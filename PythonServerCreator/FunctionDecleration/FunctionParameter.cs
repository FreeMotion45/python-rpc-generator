using System;
using System.Collections.Generic;
using System.Text;

namespace PythonServerCreator.Declaration
{
    class FunctionParameter
    {        
        public FunctionParameter(string parameterType, string parameterName)
        {
            this.ParameterType = parameterType;
            this.ParameterName = parameterName;
        }

        public string ParameterType { get; }
        public string ParameterName { get; }

        public override string ToString()
        {
            return $"{ParameterType} {ParameterName}";
        }

        public string ToPythonicDeclaration(IReadOnlyDictionary<string, string> typeMap)
        {
            // Example: a declared paramter of type: long, with name: myLongNumber, this will return: myLongNumber: int.
            // (int is also a long in python)

            return $"{ParameterName}: {typeMap[ParameterType]}";
        }
    }
}
