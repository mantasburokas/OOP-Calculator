using Calculator.Calculations.Models;
using Calculator.Operations.Collections.Interfaces;
using Calculator.Operations.Helpers;
using Calculator.Results.Interfaces;

namespace Calculator
{
    public interface ICalculator
    {
        IOperationsCollection OperationsCollection { get; }

        IResultsCaretaker ResultsCaretaker { get; }

        IResult Result { get; }

        IResult Calculate(Request request);
    }
}