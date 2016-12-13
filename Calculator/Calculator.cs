using Calculator.Operations.Collections.Interfaces;
using Calculator.Operations.Helpers;
using Calculator.Results.Interfaces;
using System;
using System.ComponentModel;
using Calculator.Calculations;
using Calculator.Calculations.Models;
using Calculator.Results;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        public IOperationsCollection OperationsCollection { get; }

        public IResultsCaretaker ResultsCaretaker { get; }

        public IResult Result { get; }

        private readonly Calculation _calculation;

        public Calculator(IOperationsCollection operationsCollection, IResultsCaretaker resultsCaretaker)
        {
            if (operationsCollection == null)
            {
                throw new ArgumentNullException(nameof(operationsCollection));
            }

            if (resultsCaretaker == null)
            {
                throw new ArgumentNullException(nameof(resultsCaretaker));
            }

            OperationsCollection = operationsCollection;

            ResultsCaretaker = resultsCaretaker;

            Result = new Result();

            var calculationXY = new CalculationXY(this);
            var calculationResultY = new CalculationResultY(this);
            var calculationXResult = new CalculationXResult(this);
            var calculationResultResult = new CalculationResultResult(this);
            var calculationUndo = new CalculationUndo(this);

            calculationXY.SetSuccessor(calculationResultY);
            calculationResultY.SetSuccessor(calculationXResult);
            calculationXResult.SetSuccessor(calculationResultResult);
            calculationResultResult.SetSuccessor(calculationUndo);

            _calculation = calculationXY;
        }

        public IResult Calculate(Request request)
        {
            return _calculation.Calculate(request);
        }
    }
}
