using Calculator.Operations.Helpers;
using Calculator.Results.Interfaces;

namespace Calculator
{
    public interface ICalculator
    {
        IResult Calculate(OperationTypes operationType, double x, double y);

        IResult Calculate(OperationTypes operationType, string side, double value);

        IResult Calculate(OperationTypes operationType);

        IResult Undo();
    }
}