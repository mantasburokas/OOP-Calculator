using Calculator.Results.Interfaces;
using Calculator.Results.Mementos.Interfaces;

namespace Calculator.Results.Mementos
{
    public class ResultMemento : IResultMemento
    {
        public double Value { get; }

        public ResultMemento(IResult result)
        {
            Value = result.Value;
        }
    }
}
