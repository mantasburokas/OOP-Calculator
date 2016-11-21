using Calculator.Operations.Interfaces;

namespace Calculator.Operations
{
    public class DivisionOperation : IOperation
    {
        public double Calculate(double x, double y)
        {
            return x / y;
        }
    }
}
