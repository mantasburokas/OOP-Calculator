using Calculator.Results.Interfaces;

namespace Calculator.Operations.Interfaces
{
    public interface IOperation
    {
        IResult Calculate(double x, double y);

        bool IsNull();
    }
}
