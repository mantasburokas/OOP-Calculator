using Calculator.Operations.Interfaces;

namespace Calculator.Operations
{
    public class SubtractionOperation : IOperation
    {
        public double Calculate(double x, double y)
        {
            return x - y;
        }
    }
}
