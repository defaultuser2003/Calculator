using System;

namespace IUnary
{
    public class AbsoluteOperation : IUnaryOperation
    {
        public double Calculate(double num)
        {
            return Math.Abs(num);
        }
    }
}
