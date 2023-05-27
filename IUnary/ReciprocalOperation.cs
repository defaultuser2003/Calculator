using System;

namespace IUnary
{
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
