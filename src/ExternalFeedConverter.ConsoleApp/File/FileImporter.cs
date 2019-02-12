using System;
using System.Collections.Generic;
using ExternalFeedConverter.ConsoleApp.Data;

namespace ExternalFeedConverter.ConsoleApp.File
{
    public class FileImporter
    {
        private readonly FileLoader _fileLoader;
        private readonly FileSanitiser _fileSanitiser;

        public FileImporter()
        {
            _fileSanitiser = new FileSanitiser();
            _fileLoader = new FileLoader();
        }

        public IEnumerable<DataItem> ImportFile(string input)
        {
            if (!System.IO.File.Exists(input))
                throw new Exception($"File {input} is not found");

            var sanitisedData = _fileSanitiser.Sanitise(input);
            var data = _fileLoader.LoadData(sanitisedData);

            return data;
        }
    }
}