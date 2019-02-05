using System.IO;
using System.Linq;

namespace ExternalFeedConverter.ConsoleApp
{
    public class FileSanitiser
    {
        public string[] Sanitise(string input)
        {
            return File.ReadAllLines(input).Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
        }
    }
}