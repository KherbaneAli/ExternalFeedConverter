using System;
using System.Collections.Generic;
using System.Linq;
using ExternalFeedConverter.ConsoleApp.Command;
using ExternalFeedConverter.ConsoleApp.Data;
using ExternalFeedConverter.ConsoleApp.Extensions;

namespace ExternalFeedConverter.ConsoleApp.Calculator
{
    public class Calculator : ICalculator 
    {
        private readonly List<CommandValue> _commandValues;

        public Calculator(List<CommandValue> commandValues)
        {
            _commandValues = commandValues ?? throw new ArgumentNullException(nameof(commandValues));
        }

        public bool CalculateLargest(string input, IEnumerable<DataItem> dataItems)
        {
            double currentLargest = 0;
            
            switch (input)
            {
                case Commands.Girth:
                    currentLargest = dataItems.Max(d => d.Girth.ToDouble());
                    break;
                case Commands.Height:
                    currentLargest = dataItems.Max(d => d.Height.ToDouble());
                    break;
                case Commands.Volume:
                    currentLargest = dataItems.Max(d => d.Volume.ToDouble());
                    break;
                case Commands.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine($"\n{input} is an invalid input! Try again.. or enter 'exit' to terminate.");
                    return false;
            }

            var value = _commandValues.First(m => m.Name.Equals(input,StringComparison.CurrentCultureIgnoreCase))?.Value;
            
            Console.WriteLine($"\nLargest Tree {input}: {currentLargest}{value}.");
            
            Console.WriteLine("\nWould you like to calculate another value? (y/n): ");
            var inp = Console.ReadLine();

            return inp != null && !inp.Equals("y");
        }
    }
}