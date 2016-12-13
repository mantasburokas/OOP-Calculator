using Calculator.Operations.Collections;
using Calculator.Operations.Collections.Interfaces;
using Calculator.Operations.Factories;
using Calculator.Operations.Factories.Interfaces;
using Calculator.Operations.Helpers;
using Calculator.Results;
using Calculator.Results.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using static System.Console;

namespace Calculator
{
    class Program
    {
        static void Main(string[] arguments)
        {
            var services = ConfigureServices();

            var calculator = services.GetService<ICalculator>();

            do
            {
                WriteLine("[operation type] [x] [y]");

                var input = ReadLine();

                if (input != null)
                {
                    var commands = input.Split(' ');

                    var operationType = (OperationTypes)Enum.Parse(typeof(OperationTypes), commands[0]);

                    if (commands[0] == OperationTypes.Undo.ToString())
                    {
                        WriteLine($"Previous result value: {calculator.Undo()}");
                    }
                    else if (commands[1] == "Result" && commands[2] == "Result")
                    {
                        WriteLine($"Result: {calculator.Calculate(operationType)}");
                    }
                    else if (commands[1] == "Result")
                    {
                        var value = double.Parse(commands[2]);

                        WriteLine($"Result: {calculator.Calculate(operationType, "Left", value)}");
                    }
                    else if (commands[2] == "Result")
                    {
                        var value = double.Parse(commands[1]);

                        WriteLine($"Result: {calculator.Calculate(operationType, "Right", value)}");
                    }
                    else if (commands[1] != "Result" && commands[2] != "Result")
                    {
                        var x = double.Parse(commands[1]);

                        var y = double.Parse(commands[2]);

                        WriteLine($"Result: {calculator.Calculate(operationType, x, y)}");
                    }

                    WriteLine("Continue? y/n");
                }

            } while (ReadKey(true).Key != ConsoleKey.N);
        }

        static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton<ICalculator, Calculator>()
                .AddSingleton<IOperationsCollection, OperationsCollection>()
                .AddSingleton<IOperationFactory, OperationFactory>()
                .AddSingleton<IResultsCaretaker, ResultsCaretaker>();

            return services.BuildServiceProvider();
        }
    }
}
