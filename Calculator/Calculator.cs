using Calculator.Operations.Collections.Interfaces;
using Calculator.Operations.Helpers;
using Calculator.Results;
using Calculator.Results.Interfaces;
using System;
using System.ComponentModel;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        private const string ResultRightSide = "Right";

        private const string ResultLeftSide = "Left";

        private readonly IOperationsCollection _operationsCollection;

        private readonly IResultsCaretaker _resultsCaretaker;

        private IResult _result;

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

            _operationsCollection = operationsCollection;

            _resultsCaretaker = resultsCaretaker;
        }

        public double Calculate(OperationTypes operationType, double x, double y)
        {
            if (!Enum.IsDefined(typeof(OperationTypes), operationType))
            {
                throw new InvalidEnumArgumentException(nameof(operationType));
            }

            var operation = _operationsCollection.GetOperation(operationType);

            _resultsCaretaker.ResultMemento = _result?.SaveResult();

            _result = new Result { Value = operation.Calculate(x, y) };

            return _result.Value;
        }

        public double Calculate(OperationTypes operationType, string side, double value)
        {
            if (_result == null)
            {
                throw new ArgumentException("Next time input numbers first, then use result");
            }

            double result;

            if (side == ResultLeftSide)
            {
                result = Calculate(operationType, _result.Value, value);
            }
            else if (side == ResultRightSide)
            {
                result = Calculate(operationType, value, _result.Value);
            }
            else
            {
                throw new InvalidEnumArgumentException("Unknown side");
            }

            return result;
        }

        public double Calculate(OperationTypes operationType)
        {
            if (_result == null)
            {
                throw new ArgumentException("Next time input numbers first, then use result");
            }

            return Calculate(operationType, _result.Value, _result.Value);
        }

        public double Undo()
        {
            var memento = _resultsCaretaker.ResultMemento;

            if (memento == null)
            {
                throw new ArgumentException("Next time input numbers first, then use result");
            }

            _result.Value = memento.Value;

            return _result.Value;
        }
    }
}
