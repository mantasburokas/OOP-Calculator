using System;
using Calculator.Calculations.Models;
using Calculator.Results.Interfaces;
using Calculator.Operations.Helpers;

namespace Calculator.Calculations
{
    public class CalculationXResult : Calculation
    {
        public CalculationXResult(ICalculator calculator) : base(calculator)
        {
        }

        public override IResult Calculate(Request request)
        {
            IResult result = null;

            if (request.ResultLeft == true && request.ResultRight == false && request.Type != OperationTypes.Undo)
            {
                var operation = Calculator.OperationsCollection.GetOperation(request.Type);

                Calculator.ResultsCaretaker.ResultMemento = Calculator.Result.SaveResult();

                var res = operation.Calculate(Calculator.Result.Value, request.Y);

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