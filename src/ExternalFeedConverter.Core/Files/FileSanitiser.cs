using System;
using System.Linq;

namespace ExternalFeedConverter.Core.Files
{
    public class FileSanitiser : IFileSanitiser
    {
        private readonly IFileProvider _fileProvider;

        public FileSanitiser(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
        }
        
        public string[] Sanitise(string input)
        {
            var lines = _fileProvider.ReadAllLines(input);
            if (lines == null)
                return new string[] { };
            
            return lines
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(s => s.Trim())
                .ToArray();
        }
    }
}