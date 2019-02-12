using System.Collections.Generic;
using ExternalFeedConverter.ConsoleApp.Data;

namespace ExternalFeedConverter.ConsoleApp
{
    public interface ICalculator
    {
        bool CalculateLargest(string input, IEnumerable<DataItem> dataItems);
    }
}