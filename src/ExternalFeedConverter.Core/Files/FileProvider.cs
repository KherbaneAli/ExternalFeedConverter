using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ExternalFeedConverter.Core.Files
{
    [ExcludeFromCodeCoverage]
    public class FileProvider : IFileProvider
    {
        public string[] ReadAllLines(string input)
        {
            return File.ReadAllLines(input);
        }
    }
}