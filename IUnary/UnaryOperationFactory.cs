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
    * Unary Operation Factory
    */
    public abstract class UnaryOperationFactory
    {
        public abstract IUnaryOperation CreateOperation(string operationName);
    }
}
