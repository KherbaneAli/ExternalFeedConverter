using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.File
{
    public interface IFileImporter
    {
        IEnumerable<DataItem> ImportFile(string input);
    }
}