using System;

namespace IUnary
{
    public class DefaultUnaryOperationFactory : UnaryOperationFactory
    {
        public override IUnaryOperation CreateOperation(string operationName)
        {
            switch (operationName)
            {
                case "abs":
                    return new AbsoluteOperation();
                case "neg":
                    return new NegateOperation();
                case "rec":
                    return new ReciprocalOperation();
                case "sqrt":
                    return new SqrtOperation();
                case "square":
                    return new SquareOperation();
                default:
                    throw new ArgumentException($"Unsupported operation: {operationName}");
            }
        }
    }
}
