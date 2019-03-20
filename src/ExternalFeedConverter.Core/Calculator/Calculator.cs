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

        public double CalculateLargest(string input, IEnumerable<DataItem> dataItems)
        {
            if (input == Commands.Exit)
                Environment.Exit(0);

            if (_selectors.ContainsKey(input) == false)
            {
                Console.WriteLine($"\n{input} is an invalid input! Try again.. or enter 'exit' to terminate.");
                return -1;
            }
            
            double currentLargest = dataItems.Max(d => _selectors[input](d).ToDouble());

            var value = _commandValues.FirstOrDefault(m => m.Name.Equals(input, StringComparison.CurrentCultureIgnoreCase))
                ?.Value;

            Console.WriteLine($"\nLargest Tree {input}: {currentLargest}{value}.");

            return currentLargest;
        }
        
    }
}