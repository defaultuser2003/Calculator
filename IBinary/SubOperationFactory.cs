namespace IBinary
{
    public class SubOperationFactory : IBinaryOperationFactory
    {
        public IBinaryOperation CreateOperation()
        {
            return new Subtraction();
        }
    }
}
