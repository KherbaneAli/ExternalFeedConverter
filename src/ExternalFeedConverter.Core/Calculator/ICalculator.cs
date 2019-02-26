using System;
using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Calculator
{
    public interface ICalculator
    {
        bool CalculateLargest(string input, IEnumerable<DataItem> dataItems);
        double ReturnLargest(string input,  IEnumerable<DataItem> dataitems);
    }
}