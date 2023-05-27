using System;

namespace IBinary
{
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
