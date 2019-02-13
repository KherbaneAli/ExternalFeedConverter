using System.Linq;

namespace ExternalFeedConverter.ConsoleApp.File
{
    public class FileSanitiser : IFileSanitiser
    {
        public string[] Sanitise(string input)
        {
            return System.IO.File.ReadAllLines(input).Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
        }
    }
}