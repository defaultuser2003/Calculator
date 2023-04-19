using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBinary
{
    /**
    * Author arborshield
    * Created by on 2023/4/2.
    * Log Factory
    */
    public class LogOperationFactory : IBinaryOperationFactory
    {
        public IBinaryOperation CreateOperation()
        {
            return new Logarithm();
        }
    }
}

