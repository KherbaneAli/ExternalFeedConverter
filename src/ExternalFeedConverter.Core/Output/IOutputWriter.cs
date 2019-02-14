using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Output
{
    public interface IOutputWriter
    {
        void PrintTable(IEnumerable<DataItem> treeList);
    }
}