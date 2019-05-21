using ExternalFeedConverter.Core.Files;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ExternalFeedConverter.Core.Test
{
    public static class FileSanitizerTests
    {
        [Fact]
        public static void Should_Sanitise_ReturnTheContentWithoutEmptyLines_WhenThereIsOne()
        {
            // Arrange
            var input = new[] {"this is a test ", "", " for file"};
            var expected = new[] {"this is a test", "for file"};

            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.ReadAllLines(Arg.Any<string>()).Returns(input);
            
            var sut = new FileSanitiser(fileProvider);
            
            // Act
            var actual = sut.Sanitise("filename");
            
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }        
        
        [Fact]
        public static void Should_Sanitise_ReturnTheContentWithoutEmptyLines_WhenTheInputIsInvalid()
        {
            // Arrange
            var expected = new string[] {};

            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.ReadAllLines(Arg.Any<string>()).Returns((string[]) null);
            
            var sut = new FileSanitiser(fileProvider);
            
            // Act
            var actual = sut.Sanitise("filename");
            
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}