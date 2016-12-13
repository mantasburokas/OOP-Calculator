using System;
using Colors.Net;
using static Colors.Net.StringStaticMethods;

namespace Calculator
{
    class ConsoleAdapter : IConsoleAdapter
    {
        private readonly ColoredConsoleWriter _console;

        public ConsoleAdapter(ColoredConsoleWriter console)
        {
            _console = console;
        }

        public void WriteLine(string text, ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Red:
                    _console.WriteLine($"{Red(text)}");
                    break;
                case ConsoleColor.Cyan:
                    _console.WriteLine($"{Cyan(text)}");
                    break;
                case ConsoleColor.Green:
                    _console.WriteLine($"{Green(text)}");
                    break;
                default:
                    _console.WriteLine($"{Magenta(text)}");
                    break;
            }
        }
    }
}
