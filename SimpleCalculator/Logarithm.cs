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
    * Log
    */
    public class Logarithm : IBinaryOperation
    {
        public double Calculate(double num1, double num2)
        {
            if (num1 <= 0 || num2 <= 0)
            {
                throw new ArgumentException("The arguments must be positive.");
            }

            return Math.Log(num1, num2);
        }
    }
}
