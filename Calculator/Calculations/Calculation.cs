using System;
using Calculator.Calculations.Models;
using Calculator.Results.Interfaces;

namespace Calculator.Calculations
{
    public abstract class Calculation
    {
        protected readonly ICalculator Calculator;

        protected Calculation Successor;

        protected Calculation(ICalculator calculator)
        {
            if (calculator == null)
            {
                throw new ArgumentNullException(nameof(calculator));
            }

            this.Calculator = calculator;
        }

        public void SetSuccessor(Calculation calculation)
        {
            Successor = calculation;
        }

        public abstract IResult Calculate(Request request);
    }
}