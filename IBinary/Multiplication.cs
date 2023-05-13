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
    * Mul
    */
    public class Multiplication : IBinaryOperation
    {
        public double Calculate(double num1, double num2)
        {
            return num1 * num2;
        }
    }
}
