using System;
using System.Collections;
using System.Collections.Generic;
using ExternalFeedConverter.Core.Data;

namespace ExternalFeedConverter.Core.Files
{
    public class FileImporter : IFileImporter
    {
        private readonly IFileLoader _fileLoader;
        private readonly IFileSanitiser _fileSanitiser;

        public FileImporter(IFileLoader fileLoader, IFileSanitiser fileSanitiser)
        {
            _fileLoader = fileLoader ?? throw new ArgumentNullException(nameof(fileLoader));
            _fileSanitiser = fileSanitiser ?? throw new ArgumentNullException(nameof(fileSanitiser));
        }

        public IEnumerable<DataItem> ImportFile(string input)
        {
            if (!System.IO.File.Exists(input))
                throw new Exception($"File {input} is not found");

            var sanitisedData = ReturnSanitisedData(input);
            var data = ReturnLoadedData(sanitisedData);

            return data;
        }

        public string[] ReturnSanitisedData(string input)
        {
            return _fileSanitiser.Sanitise(input);
        }

        public IEnumerable<DataItem> ReturnLoadedData(string[] sanitisedData)
        {
            return _fileLoader.LoadData(sanitisedData);
        }
    }
}