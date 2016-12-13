using Calculator.Operations.Helpers;

namespace Calculator.Calculations.Models
{
    public class Request
    {
        public OperationTypes Type { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public bool ResultLeft { get; set; }

        public bool ResultRight { get; set; }
    }
}