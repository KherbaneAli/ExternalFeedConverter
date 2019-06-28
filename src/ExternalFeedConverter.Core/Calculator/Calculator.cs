using System;
using System.Collections.Generic;
using System.Linq;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly List<CommandValue> _commandValues;

        private readonly Dictionary<string, string> _types =
            new Dictionary<string, string>
            {
                {"Avg", "average"},
                {"Max", "maximum"},
                {"Min", "minimum"},
                {"Sum", "total"},
            };
        
        private readonly Dictionary<string, Func<DataItem, double>> _selectors =
            new Dictionary<string, Func<DataItem, double>>
            {
                {Commands.Girth, d => d.Girth},
                {Commands.Height, d => d.Height},
                {Commands.Volume, d => d.Volume}
            };
        
        public Calculator(List<CommandValue> commandValues)
        {
            _commandValues = commandValues ?? throw new ArgumentNullException(nameof(commandValues));
        }

        public double CalculateValue(string input, string type, IEnumerable<DataItem> dataItems)
        {
            if (input == Commands.Exit)
                Environment.Exit(0);

            if (_types.ContainsKey(type) == false)
            {
                Console.WriteLine($"\n{type} is an invalid type! Try again.. or enter 'exit' to terminate.");
                return -1;
            }
            
            if (_selectors.ContainsKey(input) == false){
                Console.WriteLine($"\n{input} is an invalid attribute! Try again.. or enter 'exit' to terminate.");
                return -1;    
            }

        var value = _commandValues.FirstOrDefault(m => m.Name.Equals(input, StringComparison.CurrentCultureIgnoreCase))
                ?.Value;
            
            var current = 0.0;

            if (type.Equals("Avg")) current = current = dataItems.Average(_selectors[input]);

            else if (type.Equals("Max")) current = current = dataItems.Max(_selectors[input]);

            else if (type.Equals("Min")) current = current = dataItems.Min(_selectors[input]);

            else if (type.Equals("Sum")) current = current = dataItems.Sum(_selectors[input]);

            Console.WriteLine($"\n{type} Tree {input}: {current}{value}.");
            
            return current;
        }
        
    }
}