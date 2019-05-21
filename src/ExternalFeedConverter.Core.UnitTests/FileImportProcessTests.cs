using System;
using System.IO;
using System.Linq;
using ExternalFeedConverter.Core.Calculator;
using ExternalFeedConverter.Core.Data;
using ExternalFeedConverter.Core.Extensions;
using ExternalFeedConverter.Core.Files;
using ExternalFeedConverter.Core.Output;
using FluentAssertions;
using NSubstitute;
using Xunit;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;


namespace ExternalFeedConverter.Core.Test
{
    public static class FileImportProcessTests
    {
        
        
        [Fact]
        public static void Should_ImportFileProcess_ReturnInitialisedObject_WhenCreatingObject()
        {
            // Arrange
            var fileImporter = Substitute.For<IFileImporter>();
            var outputWriter = Substitute.For<IOutputWriter>();
            var calculator = Substitute.For<ICalculator>();
            var configuration = Substitute.For<IConfiguration>();

            
            // Act
            var fileImportProcess = new FileImportProcess(fileImporter, outputWriter, calculator, configuration);

            // Assert
            Assert.NotNull(fileImportProcess);
        }
    
        [Fact]
        public static void Should_ImportFileProcess_ReturnStringOfFileLocation_WhenCallingForFile()
        {
            // Arrange
            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.ReadAllLines(Arg.Any<string>()).Returns((string[]) null);
            
            var fileImporter = Substitute.For<IFileImporter>();
            var outputWriter = Substitute.For<IOutputWriter>();
            var calculator = Substitute.For<ICalculator>();
            var configuration = Substitute.For<IConfiguration>();
            
            var sut = new FileImportProcess(fileImporter, outputWriter, calculator, configuration);
            
            // Act
            var actual = sut.ReturnFileLocation();
            
            // Assert
            Assert.NotNull(actual);
        }
        
        [Fact]
        public static void Should_ImportFileProcess_ReturnDataItems_WhenImportingFile()
        {
            // Arrange
            var inpdata = new[]
            {
                "Index, Girth (in), Height (ft), Volume(ft^3)",
                "1,   8.3,     70,   10.3, Willow, True",
                "2,   8.6,     65,   10.3, Oak, False"
            };
            
            File.WriteAllText(@"test.csv", string.Join(",", inpdata));
            
            string input = AppDomain.CurrentDomain.BaseDirectory;
            
            var expected = from row in inpdata.Skip(1)
                let data = row.Split(',')
                select new DataItem
                (
                    data[0].ToInt(),
                    data[1].ToDouble(),
                    data[2].ToDouble(),
                    data[3].ToDouble(),
                    data[4],
                    data[5].ToBoolean()
                );
            
            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.ReadAllLines(Arg.Any<string>()).Returns(inpdata);
            
            var fileSanitiser = new FileSanitiser(fileProvider);
            var fileLoader = new FileLoader();
            
            var fileImporter = new FileImporter(fileLoader, fileSanitiser);
            var outputWriter = Substitute.For<IOutputWriter>();
            var calculator = Substitute.For<ICalculator>();
            var configuration = Substitute.For<IConfiguration>();
            
            var sut = new FileImportProcess(fileImporter, outputWriter, calculator, configuration);
            
            // Act
            var actual = sut.LoadData($@"{input}test.csv");
            
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
        /*
        [Fact]
        public static void Should_ImportFileProcess_RunMethod_WhenCalculatingMax()
        {
            // Arrange
            var inpdata = new[]
            {
                "Index, Girth (in), Height (ft), Volume(ft^3)",
                "1,   8.3,     70,   10.3",
                "2,   8.6,     65,   10.3"
            };

            File.WriteAllText(@"test.csv", string.Join(",", inpdata));

            string input = AppDomain.CurrentDomain.BaseDirectory;

            var expected = from row in inpdata.Skip(1)
                let data = row.Split(',')
                select new DataItem
                (
                    data[0],
                    data[1],
                    data[2],
                    data[3]
                );

            
            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.ReadAllLines(Arg.Any<string>()).Returns(inpdata);

            var fileSanitiser = new FileSanitiser(fileProvider);
            var fileLoader = new FileLoader();

            var fileImporter = new FileImporter(fileLoader, fileSanitiser);
            var outputWriter = Substitute.For<IOutputWriter>();
            var calculator = Substitute.For<ICalculator>();
            var configuration = Substitute.For<IConfiguration>();

            var sut = new FileImportProcess(fileImporter, outputWriter, calculator, configuration);

            var dataItems = sut.LoadData($@"{input}\test.csv");

            var treeList = dataItems as DataItem[] ?? dataItems.ToArray();
            outputWriter.PrintTable(treeList);
            
            var enumerable = treeList.ToList();

            // Act
            sut.CalculateMax(enumerable);
            // Assert
        
        }*/
    }
}