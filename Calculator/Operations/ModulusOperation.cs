using Calculator.Operations.Interfaces;

namespace Calculator.Operations
{
    class ModulusOperation : IOperation
    {
        public double Calculate(double x, double y)
        {
            return x % y;
        }
    }
}
