using Calculator.Operations.Helpers;
using Calculator.Operations.Interfaces;

namespace Calculator.Operations.Factories.Interfaces
{
    public interface IOperationFactory
    {
        IOperation CreateOperation(OperationTypes operationType);
    }
}