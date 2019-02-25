using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Files
{
    public interface IFileImporter
    {
        IEnumerable<DataItem> ImportFile(string input);
    }
}