using Calculator.Results.Interfaces;
using Calculator.Results.Mementos;
using Calculator.Results.Mementos.Interfaces;

namespace Calculator.Results
{
    public class Result : IResult
    {
        public double Value { get; set; }

        public IResultMemento SaveResult()
        {
            return new ResultMemento(this);
        }

        public void RestoreResult(IResultMemento memento)
        {
            Value = memento.Value;
        } 
    }
}