using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Cavity.Data;
using ExternalFeedConverter.Core.Data;
using ExternalFeedConverter.Core.Files;
using FluentAssertions;
using NSubstitute;
using Xunit;


namespace ExternalFeedConverter.Core.Test
{
    public class FileImporterTests
    {
        [Fact]
        public static void Should_Import_ReturnException_WhenFileNotFound()
        {
            // Arrange
            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.ReadAllLines(Arg.Any<string>()).Returns((string[]) null);
            
            var fileSanitiser = new FileSanitiser(fileProvider);
            var fileLoader = new FileLoader();
            
            var sut = new FileImporter(fileLoader, fileSanitiser);
            
            // Act
            var exception = Record.Exception(() => sut.ImportFile(""));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
        }
        
        [Fact]
        [CsvData(@"C:\MyCsv.csv")]
        public static void Should_Import_ReturnImportedData_WhenFileIsFound()
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
            
            var sut = new FileImporter(fileLoader, fileSanitiser);

            // Act
            var actual = sut.ImportFile($@"{input}\test.csv");

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public static void Should_Import_ReturnSanitisedData_WhenInputIsValid()
        {
            // Arrange
            var input = new[] {"this is a test ", "", " for file"};
            var expected = new[] {"this is a test", "for file"};
            
            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.ReadAllLines(Arg.Any<string>()).Returns(input);
            
            var fileSanitiser = new FileSanitiser(fileProvider);
            var fileLoader = new FileLoader();
            
            var sut = new FileImporter( fileLoader, fileSanitiser);
            
            // Act
            var actual = sut.ReturnSanitisedData("filename");

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public static void Should_Import_ReturnLoadedData_WhenInputIsValid()
        {
            // Arrange
            string[] input = new string[]
            {
                "Tree,Girth,Height,Volume",
                "1,8.3,70,10.3"
            };
            
            var expected = new DataItem
            (
                "1",
                "8.3",
                "70",
                "10.3"
            );
            
            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.ReadAllLines(Arg.Any<string>()).Returns(input);

            var fileSanitiser = new FileSanitiser(fileProvider);
            var fileLoader = new FileLoader();
            
            var sut = new FileImporter(fileLoader, fileSanitiser);
            
            // Act
            var actual = sut.ReturnLoadedData(input);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}