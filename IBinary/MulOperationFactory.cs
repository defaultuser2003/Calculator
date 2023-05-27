namespace IBinary
{
    public class MulOperationFactory : IBinaryOperationFactory
    {
        public IBinaryOperation CreateOperation()
        {
            return new Multiplication();
        }
    }
}
