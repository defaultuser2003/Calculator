using System;

namespace IUnary
{
    public class SqrtOperation : IUnaryOperation
    {
        public double Calculate(double num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Cannot take square root of negative number.");
            }
            return Math.Sqrt(num);
        }
    }
}
