using System.Collections.Generic;
using ExternalFeedConverter.ConsoleApp.Data;

namespace ExternalFeedConverter.ConsoleApp.Output
{
    public interface IOutputWriter
    {
        void PrintTable(IEnumerable<DataItem> treeList);
    }
}