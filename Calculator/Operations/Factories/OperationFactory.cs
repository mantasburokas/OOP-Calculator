using Calculator.Operations.Factories.Interfaces;
using Calculator.Operations.Helpers;
using Calculator.Operations.Interfaces;

namespace Calculator.Operations.Factories
{
    public sealed class OperationFactory : IOperationFactory
    {
        public IOperation CreateOperation(OperationTypes operationType)
        {

            IOperation newOperation = null;

            switch (operationType)
            {
                case OperationTypes.Addition:
                    newOperation = new AdditionOperation();
                    break;
                case OperationTypes.Subtraction:
                    newOperation = new SubtractionOperation();
                    break;
                case OperationTypes.Multiplication:
                    newOperation = new MultiplicationOperation();
                    break;
                case OperationTypes.Division:
                    newOperation = new DivisionOperation();
                    break;
                case OperationTypes.Modulus:
                    newOperation = new ModulusOperation();
                    break;
                case OperationTypes.Undefined:
                    newOperation = new NullOperation();
                    break;
            }

            return newOperation;
        }
    }
}
