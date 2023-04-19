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
    * Div
    */
    public class Division : IBinaryOperation
    {
        public double Calculate(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return num1 / num2;
        }
    }

}
