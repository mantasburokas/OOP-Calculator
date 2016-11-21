using Calculator.Operations.Interfaces;

namespace Calculator.Operations
{
    public class AdditionOperation : IOperation
    {
        public double Calculate(double x, double y)
        {
            return x + y;
        }
    }
}
