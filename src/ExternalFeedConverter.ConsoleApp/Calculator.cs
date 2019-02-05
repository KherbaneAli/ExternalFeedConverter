using System;
using System.Collections.Generic;
using System.Linq;

namespace ExternalFeedConverter.ConsoleApp
{
    public class Calculator
    {
        public bool CalculateLargest(string input, IEnumerable<DataItem> dataItems)
        {
            double currentLargest = 0;

            var measurement = string.Empty;

            switch (input.ToLower())
            {
                case Commands.Girth:
                    measurement = "in";
                    currentLargest = dataItems.Max(d => d.Girth.ToDouble());
                    break;
                case Commands.Height:
                    measurement = "ft";
                    currentLargest = dataItems.Max(d => d.Height.ToDouble());
                    break;
                case Commands.Volume:
                    measurement = "ft^3";
                    currentLargest = dataItems.Max(d => d.Volume.ToDouble());
                    break;
                case Commands.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid input! Try again.. or enter 'exit' to terminate.");
                    return false;
            }

            Console.WriteLine("\nLargest Tree {0}: {1}{2}.", input, currentLargest, measurement);

            Console.WriteLine("\nWould you like to calculate another value? (y/n): ");
            var inp = Console.ReadLine();

            return inp != null && !inp.Equals("y");
        }
    }
}