using System.Collections.Generic;
using ExternalFeedConverter.ConsoleApp.Data;

namespace ExternalFeedConverter.ConsoleApp.File
{
    public interface IFileImporter
    {
        IEnumerable<DataItem> ImportFile(string input);
    }
}