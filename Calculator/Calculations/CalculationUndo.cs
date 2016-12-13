using System;
using Calculator.Calculations.Models;
using Calculator.Operations.Helpers;
using Calculator.Results.Interfaces;

namespace Calculator.Calculations
{
    public class CalculationUndo : Calculation
    {
        public CalculationUndo(ICalculator calculator) : base(calculator)
        {
        }

        public override IResult Calculate(Request request)
        {
            IResult result = null;

            if (request.Type == OperationTypes.Undo)
            {
                var memento = Calculator.ResultsCaretaker.ResultMemento;

                if (memento == null)
                {
                    throw new ArgumentException("No previous value available");
                }

                Calculator.Result.Value = memento.Value;

                result = Calculator.Result;
            }
            else
            {
                result = Successor.Calculate(request);
            }

            return result;
        }
    }
}