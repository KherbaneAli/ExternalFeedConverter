using System;
using System.Collections.Generic;
using System.Linq;
using ExternalFeedConverter.Core.Data;
using ExternalFeedConverter.Core.Extensions;

namespace ExternalFeedConverter.Core.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly List<CommandValue> _commandValues;

        private readonly Dictionary<string, Func<DataItem, string>> _selectors =
            new Dictionary<string, Func<DataItem, string>>
            {
                {Commands.Girth, d => d.Girth},
                {Commands.Height, d => d.Height},
                {Commands.Volume, d => d.Volume}
            };
        
        public Calculator(List<CommandValue> commandValues)
        {
            _commandValues = commandValues ?? throw new ArgumentNullException(nameof(commandValues));
        }

        public bool CalculateLargest(string input, IEnumerable<DataItem> dataItems)
        {
            if (input == Commands.Exit)
                Environment.Exit(0);


            if (_selectors.ContainsKey(input) == false)
            {
                Console.WriteLine($"\n{input} is an invalid input! Try again.. or enter 'exit' to terminate.");
                return false;
            }
            
            double currentLargest = ReturnLargest(input, dataItems);

            var value = _commandValues.First(m => m.Name.Equals(input, StringComparison.CurrentCultureIgnoreCase))
                ?.Value;

            Console.WriteLine($"\nLargest Tree {input}: {currentLargest}{value}.");

            Console.WriteLine("\nWould you like to calculate another value? (y/n): ");
            var inp = Console.ReadLine();

            return inp != null && !inp.Equals("y");
        }

        public double ReturnLargest(string input, IEnumerable<DataItem> dataItems)
        {
            return dataItems.Max(d => _selectors[input](d).ToDouble());
        }
    }
}