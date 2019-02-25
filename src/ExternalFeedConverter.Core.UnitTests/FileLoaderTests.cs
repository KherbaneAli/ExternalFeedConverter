using ExternalFeedConverter.Core.Data;
using ExternalFeedConverter.Core.Files;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ExternalFeedConverter.Core.Test
{
    public class FileLoaderTests
    {
        [Fact]
        public static void Should_Load_ReturnDataItemWithFieldsFromArray_WhenInputIsValid()
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
            
            var sut = new FileLoader();

            // Act
            var actual = sut.LoadData(input);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public static void Should_Load_ReturnNull_WhenTheInputIsInvalid()
        {
            // Arrange
            var input = new string[] {};
            var expected = "";
            
            var sut = new FileLoader();
            
            var fileProvider = Substitute.For<IFileProvider>();
            fileProvider.ReadAllLines(Arg.Any<string>()).Returns(input);
            
            // Act
            var actual = sut.LoadData(input);
            
            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}