using Calculator.Operations.Helpers;

namespace Calculator
{
    public interface ICalculator
    {
        double Calculate(OperationTypes operationType, double x, double y);

        double Calculate(OperationTypes operationType, string side, double value);

        double Calculate(OperationTypes operationType);

        double Undo();
    }
}