using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using ExternalFeedConverter.ConsoleApp.Command;
using ExternalFeedConverter.ConsoleApp.Extensions;
using ExternalFeedConverter.ConsoleApp.File;
using ExternalFeedConverter.ConsoleApp.Output;
using Microsoft.Extensions.Configuration;

namespace ExternalFeedConverter.ConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var configuration = BuildConfiguration(args);

                var commandValues = new List<CommandValue>();
                configuration.GetSection("CalculationOption").Bind(commandValues);

                var inputFile = configuration.GetValue<string>("DefaultFileLocation");

                var fileImporter = new FileImporter();
                var dataItems = fileImporter.ImportFile(inputFile);

                var outputWriter = new OutputWriter();

                var enumerable = dataItems.ToList();
                outputWriter.PrintTable(enumerable.ToList());

                var calculator = new Calculator.Calculator(commandValues);
                var calculated = false;

                while (calculated == false)
                {
                    Console.Write(
                        "\nPlease enter the attribute (girth/height/volume) you would like to find the largest of: ");

                    var input = Console.ReadLine();

                    Thread.Sleep(1000);

                    calculated = calculator.CalculateLargest(input.ToCapitalCase(), enumerable);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private static IConfiguration BuildConfiguration(string[] args)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .Build();
        }
    }
}