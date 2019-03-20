using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using ExternalFeedConverter.Core;
using ExternalFeedConverter.Core.Calculator;
using ExternalFeedConverter.Core.Files;
using ExternalFeedConverter.Core.Output;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Entity or Dapper for DB
namespace ExternalFeedConverter.ConsoleApp
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var configuration = BuildConfiguration(args);
                var provider = BuildServiceProvider(configuration);

                var importProcess = provider.GetRequiredService<IFileImportProcess>();

                importProcess.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private static IServiceProvider BuildServiceProvider(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            services.AddTransient<IFileImporter, FileImporter>();
            services.AddTransient<IOutputWriter, OutputWriter>();
            services.AddTransient<IFileLoader, FileLoader>();
            services.AddTransient<IFileSanitiser, FileSanitiser>();
            services.AddTransient<IFileImportProcess, FileImportProcess>();
            services.AddTransient<IFileProvider, FileProvider>();

            services.AddSingleton(configuration);
            
            services.AddTransient<ICalculator>(sp =>
            {
                var commandValues = new List<CommandValue>();
                configuration.GetSection("CalculationOption").Bind(commandValues);
                
                return new Calculator(commandValues);
            });
            return services.BuildServiceProvider();
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