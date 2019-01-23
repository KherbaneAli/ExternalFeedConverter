using System.IO;
using System.Linq;

namespace ExternalFeedConverter.ConsoleApp
{
    public class FileDataSanitiser
    {
        public void Sanitise(string input, string output)
        {
            File.WriteAllLines(output, File.ReadAllLines(input).Where(l => !string.IsNullOrWhiteSpace(l)));
        }
    }
}