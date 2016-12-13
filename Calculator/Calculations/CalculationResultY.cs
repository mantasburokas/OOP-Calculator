using Calculator.Calculations.Models;
using Calculator.Operations.Helpers;
using Calculator.Results.Interfaces;

namespace Calculator.Calculations
{
    public class CalculationResultY : Calculation
    {
        public CalculationResultY(ICalculator calculator) : base(calculator)
        {
        }

        public override IResult Calculate(Request request)
        {
            IResult result = null;

            if (request.ResultLeft == false && request.ResultRight == true && request.Type != OperationTypes.Undo)
            {
                var operation = Calculator.OperationsCollection.GetOperation(request.Type);

                Calculator.ResultsCaretaker.ResultMemento = Calculator.Result.SaveResult();

                var res = operation.Calculate(request.X, Calculator.Result.Value);

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