using System;
using System.Linq;
using System.Threading;

namespace ExternalFeedConverter.ConsoleApp
{
    public static class Program
    {
        private const string DefaultFileLocation = @"..\..\src\ExternalFeedConverter.ConsoleApp\data\trees.csv";

        public static void Main(string[] args)
        {
            try
            {
                var inputFile = args.Any()
                    ? DefaultFileLocation
                    : args.First();

                var fileImporter = new FileImporter();
                var dataItems = fileImporter.ImportFile(inputFile);
        
                var outputWriter = new OutputWriter();
                
                var enumerable = dataItems.ToList();
                outputWriter.PrintTable(enumerable.ToList());

                var calculator = new Calculator();
                var calculated = false;

                while (calculated == false)
                {
                    Console.Write(
                        "\nPlease enter the attribute (girth/height/volume) you would like to find the largest of: ");

                    var input = Console.ReadLine();

                    Thread.Sleep(1000);

                    calculated = calculator.CalculateLargest(input, enumerable);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

    }

    public static class Commands
    {
        public const string Girth = "girth";
        public const string Height = "height";
        public const string Volume = "volume";
        public const string Exit = "exit";
    }
}


/*
 1- Breaking the Program class to exclude what is not relevant to the class 
 2- Read the mapping for measurement from configuration. Json
         https://garywoodfine.com/configuration-api-net-core-console-application/
         https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2
         
 * 
*/