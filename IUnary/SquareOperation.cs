namespace IUnary
{
    public class SquareOperation : IUnaryOperation
    {
        public double Calculate(double num)
        {
            return num * num;
        }
    }
}
