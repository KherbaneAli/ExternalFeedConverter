using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.File
{
    public interface IFileLoader
    {
        IEnumerable<DataItem> LoadData(string[] rows);
    }
}