using System;
using System.Linq;
using System.Threading;
using ExternalFeedConverter.Core.Calculator;
using ExternalFeedConverter.Core.Extensions;
using ExternalFeedConverter.Core.File;
using ExternalFeedConverter.Core.Output;
using Microsoft.Extensions.Configuration;

namespace ExternalFeedConverter.Core
{
    public class FileImportProcess : IFileImportProcess
    {
        private readonly IFileImporter _fileImporter;
        private readonly IOutputWriter _outputWriter;
        private readonly ICalculator _calculator;
        private readonly IConfiguration _configuration;

        public FileImportProcess(IFileImporter fileImporter, IOutputWriter outputWriter, 
            ICalculator calculator, IConfiguration configuration)
        {
            _fileImporter = fileImporter ?? throw new ArgumentNullException(nameof(fileImporter));
            _outputWriter = outputWriter ?? throw new ArgumentNullException(nameof(outputWriter));
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        
        public void Run()
        {
            var inputFile = _configuration.GetValue<string>("DefaultFileLocation");
            var dataItems = _fileImporter.ImportFile(inputFile);

            var enumerable = dataItems.ToList();
            _outputWriter.PrintTable(enumerable.ToList());
                
            var calculated = false;

            while (calculated == false)
            {
                Console.Write(
                    "\nPlease enter the attribute (girth/height/volume) you would like to find the largest of: ");

                var input = Console.ReadLine();

                Thread.Sleep(1000);

                calculated = _calculator.CalculateLargest(input.ToCapitalCase(), enumerable);
            }
        }
    }
}