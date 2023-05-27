namespace IUnary
{
    public class NegateOperation : IUnaryOperation
    {
        public double Calculate(double num)
        {
            return -num;
        }
    }
}
