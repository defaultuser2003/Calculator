using System;
using System.Configuration;

namespace IBinary
{
    public class BinaryOperationFactory
    {
        public static IBinaryOperation CreateOperation(string operatorName)
        {
            // Get the fully-qualified name of the operation class from the config file
            string operationClassName = ConfigurationManager.AppSettings[operatorName];

            // Use reflection to create an instance of the operation class
            Type operationClassType = Type.GetType(operationClassName);
            IBinaryOperation operation = (IBinaryOperation)Activator.CreateInstance(operationClassType);

            return operation;
        }
    }
}

