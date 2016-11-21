using Calculator.Results.Mementos.Interfaces;

namespace Calculator.Results.Interfaces
{
    public interface IResultsCaretaker
    {
        IResultMemento ResultMemento { get; set; }
    }
}