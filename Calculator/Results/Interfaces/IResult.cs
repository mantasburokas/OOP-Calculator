using Calculator.Results.Mementos.Interfaces;

namespace Calculator.Results.Interfaces
{
    public interface IResult
    {
        double Value { get; set; }

        IResultMemento SaveResult();

        void RestoreResult(IResultMemento memento);
    }
}