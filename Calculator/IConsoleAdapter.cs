using System;

namespace Calculator
{
    public interface IConsoleAdapter
    {
        void WriteLine(string text, ConsoleColor color);
    }
}