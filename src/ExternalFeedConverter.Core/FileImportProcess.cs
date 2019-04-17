using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ExternalFeedConverter.Core.Calculator;
using ExternalFeedConverter.Core.Data;
using ExternalFeedConverter.Core.Extensions;
using ExternalFeedConverter.Core.Files;
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
            var inputFile = ReturnFileLocation();
            var dataItems = LoadData(inputFile);

            var treeList = dataItems as DataItem[] ?? dataItems.ToArray();
            _outputWriter.PrintTable(treeList);
            
            var enumerable = treeList.ToList();

            CalculateMax(enumerable);
           
        }
        
        public void CalculateMax(List<DataItem> enumerable)
        {
            var finished = false;

            while (finished == false)
            {
                Console.Write(
                    "\nPlease enter the attribute (girth/height/volume) you would like to find the largest of: ");

                var input = Console.ReadLine();

                Thread.Sleep(1000);

                var calculated = _calculator.CalculateLargest(input.ToCapitalCase(), enumerable);
                
                if (!(calculated > 0)) continue;
                Console.WriteLine("\nWould you like to calculate another value? (y/n): ");
                var inp = Console.ReadLine();
                finished = inp != null && !inp.Equals("y");
            }
        }

        public IEnumerable<DataItem> LoadData(string inputFile)
        {
            return _fileImporter.ImportFile(inputFile);
        }

        public string ReturnFileLocation()
        {
            return _configuration.GetValue<string>("DefaultFileLocation");
        }
    }
}