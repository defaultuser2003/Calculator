using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUnary
{
    /**
    * Author arborshield
    * Created by on 2023/4/2.
    * Default Unary Operation Factory
    */
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
