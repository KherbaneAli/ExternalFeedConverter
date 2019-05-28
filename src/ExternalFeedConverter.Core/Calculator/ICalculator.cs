using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Calculator
{
    public interface ICalculator
    {
        double CalculateValue(string input, string type, IEnumerable<DataItem> dataItems);
    }
}