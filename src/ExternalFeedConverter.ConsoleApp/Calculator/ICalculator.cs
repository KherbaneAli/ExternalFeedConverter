using System.Collections.Generic;
using ExternalFeedConverter.ConsoleApp.Data;

namespace ExternalFeedConverter.ConsoleApp.Calculator
{
    public interface ICalculator
    {
        bool CalculateLargest(string input, IEnumerable<DataItem> dataItems);
    }
}