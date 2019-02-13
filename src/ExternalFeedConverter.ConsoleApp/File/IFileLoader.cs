using System.Collections.Generic;
using ExternalFeedConverter.ConsoleApp.Data;

namespace ExternalFeedConverter.ConsoleApp.File
{
    public interface IFileLoader
    {
        IEnumerable<DataItem> LoadData(string[] rows);
    }
}