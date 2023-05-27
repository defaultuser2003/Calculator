namespace IUnary
{
    public abstract class UnaryOperationFactory
    {
        public abstract IUnaryOperation CreateOperation(string operationName);
    }
}
