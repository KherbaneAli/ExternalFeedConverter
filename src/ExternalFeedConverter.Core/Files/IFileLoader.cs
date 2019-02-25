using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Files
{
    public interface IFileLoader
    {
        IEnumerable<DataItem> LoadData(string[] rows);
    }
}