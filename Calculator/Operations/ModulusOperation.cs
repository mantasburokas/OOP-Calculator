using Calculator.Operations.Interfaces;
using Calculator.Results;
using Calculator.Results.Interfaces;

namespace Calculator.Operations
{
    class ModulusOperation : IOperation
    {
        public IResult Calculate(double x, double y)
        {
            return new Result { Value = x % y };
        }

        public bool IsNull()
        {
            return false;
        }
    }
}
