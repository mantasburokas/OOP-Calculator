using Calculator.Results.Interfaces;
using Calculator.Results.Mementos.Interfaces;

namespace Calculator.Results
{
    public class ResultsCaretaker : IResultsCaretaker
    {
        private IResultMemento _resultMemento;

        public IResultMemento ResultMemento
        {
            get
            {
                IResultMemento memento = null;

                if (_resultMemento != null)
                {
                    memento = _resultMemento;

                    _resultMemento = null;
                }

                return memento;
            }
            set
            {
                _resultMemento = value;
            }
        }
    }
}