using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBinary
{
    /**
    * Author arborshield
    * Created by on 2023/4/2.
    * Binary Operation Factory
    */
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

