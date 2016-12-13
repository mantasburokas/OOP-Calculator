using Calculator.Operations.Interfaces;
using Calculator.Results;
using Calculator.Results.Interfaces;

namespace Calculator.Operations
{
    public class NullOperation : IOperation
    {
        public IResult Calculate(double x, double y)
        {
            return new NullResult { Value = double.MinValue };
        }

        public bool IsNull()
        {
            return true;
        }
    }
}