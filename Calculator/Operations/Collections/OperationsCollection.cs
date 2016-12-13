using Calculator.Operations.Collections.Interfaces;
using Calculator.Operations.Factories.Interfaces;
using Calculator.Operations.Helpers;
using Calculator.Operations.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Calculator.Operations.Collections
{
    class OperationsCollection : IOperationsCollection
    {
        private readonly Dictionary<OperationTypes, IOperation> _operations;

        private readonly IOperationFactory _operationFactory;

        public OperationsCollection(IOperationFactory operationFactory)
        {
            if (operationFactory == null)
            {
                throw new ArgumentNullException(nameof(operationFactory));
            }

            _operations = new Dictionary<OperationTypes, IOperation>();

            _operationFactory = operationFactory;
        }

        public IOperation GetOperation(OperationTypes operationType)
        {
            if (!Enum.IsDefined(typeof(OperationTypes), operationType))
            {
                throw new InvalidEnumArgumentException(nameof(operationType));
            }

            if (_operations.ContainsKey(operationType))
            {
                return _operations[operationType];
            }

            var operation = _operationFactory.CreateOperation(operationType);

            _operations.Add(operationType, operation);

            return operation;
        }
    }
}
