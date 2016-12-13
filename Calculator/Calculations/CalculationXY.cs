using Calculator.Calculations.Models;
using Calculator.Operations.Helpers;
using Calculator.Results.Interfaces;

namespace Calculator.Calculations
{
    public class CalculationXY : Calculation
    {
        public CalculationXY(ICalculator calculator) : base(calculator)
        {
        }

        public override IResult Calculate(Request request)
        {
            IResult result = null;

            if (request.ResultLeft == false && request.ResultRight == false && request.Type != OperationTypes.Undo)
            {
                var operation = Calculator.OperationsCollection.GetOperation(request.Type);

                Calculator.ResultsCaretaker.ResultMemento = Calculator.Result.SaveResult();

                var res = operation.Calculate(request.X, request.Y);

                Calculator.Result.Value = res.Value;

                result = res;
            }
            else
            {
                result = Successor.Calculate(request);
            }

            return result;
        }
    }
}
