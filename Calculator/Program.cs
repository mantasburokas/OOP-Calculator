using Calculator.Operations.Collections;
using Calculator.Operations.Collections.Interfaces;
using Calculator.Operations.Factories;
using Calculator.Operations.Factories.Interfaces;
using Calculator.Operations.Helpers;
using Calculator.Results;
using Calculator.Results.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using Colors.Net;

namespace Calculator
{
    class Program
    {
        static void Main(string[] arguments)
        {
            var services = ConfigureServices();

            var calculator = services.GetService<ICalculator>();

            var console = services.GetService<IConsoleAdapter>();

            do
            {
                console.WriteLine("[operation type] [x] [y]", ConsoleColor.Cyan);

                var input = Console.ReadLine();

                if (input != null)
                {
                    var commands = input.Split(' ');

                    OperationTypes operationType;

                    var isDefined = Enum.TryParse(commands[0], true, out operationType);

                    if (!isDefined)
                    {
                        operationType = OperationTypes.Undefined; ;
                    }

                    IResult result = null;

                    if (commands[0] == OperationTypes.Undo.ToString())
                    {
                        result = calculator.Undo();
                    }
                    else if (commands[1] == "Result" && commands[2] == "Result")
                    {
                        result = calculator.Calculate(operationType);
                    }
                    else if (commands[1] == "Result")
                    {
                        var value = double.Parse(commands[2]);

                        result = calculator.Calculate(operationType, "Left", value);
                    }
                    else if (commands[2] == "Result")
                    {
                        var value = double.Parse(commands[1]);

                        result = calculator.Calculate(operationType, "Right", value);
                    }
                    else if (commands[1] != "Result" && commands[2] != "Result")
                    {
                        var x = double.Parse(commands[1]);

                        var y = double.Parse(commands[2]);

                        result = calculator.Calculate(operationType, x, y);
                    }

                    if (result == null)
                    {
                        throw new ArgumentNullException();
                    }

                    if (result.IsNull() || result.Value == double.MinValue)
                    {
                        console.WriteLine("Unsupported operation", ConsoleColor.Red);
                    }
                    else
                    {
                        console.WriteLine($"Result: {result.Value}", ConsoleColor.Green); 
                    }

                    console.WriteLine("Continue? y/n", ConsoleColor.Magenta);
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.N);
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton<ICalculator, Calculator>()
                .AddSingleton<IOperationsCollection, OperationsCollection>()
                .AddSingleton<IOperationFactory, OperationFactory>()
                .AddSingleton<IResultsCaretaker, ResultsCaretaker>()
                .AddSingleton(new ColoredConsoleWriter(Console.Out))
                .AddSingleton<IConsoleAdapter, ConsoleAdapter>();

            return services.BuildServiceProvider();
        }
    }
}
