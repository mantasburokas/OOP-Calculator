using Calculator.Operations.Interfaces;

namespace Calculator.Operations
{
    public class MultiplicationOperation : IOperation
    {
        public double Calculate(double x, double y)
        {
            return x * y;
        }
    }
}
