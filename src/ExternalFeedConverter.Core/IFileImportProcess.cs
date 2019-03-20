using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core
{
    public interface IFileImportProcess
    {
        void Run();
        IEnumerable<DataItem> LoadData(string input);
        string ReturnFileLocation();
        void CalculateMax(List<DataItem> enumerable);
    }
}