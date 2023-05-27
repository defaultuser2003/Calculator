namespace IBinary
{
    public class DivOperationFactory : IBinaryOperationFactory
    {
        public IBinaryOperation CreateOperation()
        {
            return new Division();
        }
    }
}
