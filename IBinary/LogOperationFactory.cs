namespace IBinary
{
    public class LogOperationFactory : IBinaryOperationFactory
    {
        public IBinaryOperation CreateOperation()
        {
            return new Logarithm();
        }
    }
}

