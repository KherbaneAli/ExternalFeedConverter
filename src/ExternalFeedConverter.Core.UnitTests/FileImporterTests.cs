using System;
using ExternalFeedConverter.Core.Files;
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
            var input = "doesnotexist.csv";
            
            var fileSanitiser = Substitute.For<IFileSanitiser>();
            var fileLoader = Substitute.For<IFileLoader>();
            
            var sut = new FileImporter(fileLoader, fileSanitiser);
            
            // Act
            var exception = Record.Exception(() => sut.ImportFile(input));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
        }
    }
}