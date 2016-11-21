using Calculator.Results.Interfaces;
using Calculator.Results.Mementos.Interfaces;

namespace Calculator.Results
{
    public sealed class ResultsCaretaker : IResultsCaretaker
    {
        private static IResultsCaretaker _instance;

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

        private ResultsCaretaker()
        {    
        }

        public static IResultsCaretaker GetInstance()
        {
            return _instance ?? (_instance = new ResultsCaretaker());
        }
    }
}