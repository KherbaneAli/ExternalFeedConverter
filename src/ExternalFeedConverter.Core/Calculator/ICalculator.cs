using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Calculator
{
    public interface ICalculator
    {
        double CalculateLargest(string input, IEnumerable<DataItem> dataItems);
    }
}