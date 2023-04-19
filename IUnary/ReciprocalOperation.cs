using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUnary
{
    /**
    * Author arborshield
    * Created by on 2023/4/2.
    * Rec
    */
    public class ReciprocalOperation : IUnaryOperation
    {
        public double Calculate(double num)
        {
            if (num == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }
            return 1 / num;
        }
    }
}
