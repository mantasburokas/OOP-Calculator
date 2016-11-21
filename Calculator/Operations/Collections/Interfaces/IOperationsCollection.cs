using Calculator.Operations.Helpers;
using Calculator.Operations.Interfaces;

namespace Calculator.Operations.Collections.Interfaces
{
    public interface IOperationsCollection
    {
        IOperation GetOperation(OperationTypes operationType);
    }
}