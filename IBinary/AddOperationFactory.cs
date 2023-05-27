namespace IBinary
{
    public class AddOperationFactory : IBinaryOperationFactory
    {
        public IBinaryOperation CreateOperation()
        {
            return new Addition();
        }
    }
}
