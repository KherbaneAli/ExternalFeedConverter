using System.Collections.Generic;
using System.Linq;
using ExternalFeedConverter.Core.Calculator;
using ExternalFeedConverter.Core.Data;
using FluentAssertions;
using Xunit;

// FIX THIS TESTING
namespace ExternalFeedConverter.Core.Test
{
    public class CalculatorTests
    {
        public static List<CommandValue> commandValues = new List<CommandValue>();
        
        [Fact]
        public static void Should_Calculate_ReturnMaxValueForGirth_WhenInputIsValid()
        {
            // Arrange
            var input = "Girth";
            var inpdata = new[]
            {

                "1,   8.3,     70,   10.3",
                "2,   8.6,     65,   10.3"
            };

            var expected = 8.6;
            
            var dataitems = from row in inpdata
                let data = row.Split(',')
                select new DataItem
                (
                    data[0],
                    data[1],
                    data[2],
                    data[3]
                );

            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateLargest(input, dataitems);

            // Assert
            actual.Should().BeGreaterOrEqualTo(expected);

        }

        [Fact]
        public static void Should_Calculate_ReturnMaxValueForHeight_WhenInputIsValid()
        {
            // Arrange
            var input = "Height";
            var inpdata = new[]
            {
                "Index, Girth (in), Height (ft), Volume(ft^3)",
                "1,   8.3,     70,   10.3",
                "2,   8.6,     65,   10.3"
            };

            var expected = 70;
            
            var dataitems = from row in inpdata
                let data = row.Split(',')
                select new DataItem
                (
                    data[0],
                    data[1],
                    data[2],
                    data[3]
                );
            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateLargest(input, dataitems);

            // Assert
            actual.Should().BeGreaterOrEqualTo(expected);
        }

        [Fact]
        public static void Should_Calculate_ReturnMaxValueForVolume_WhenInputIsValid()
        {
            // Arrange
            var input = "Volume";
            var inpdata = new[]
            {
                "Index, Girth (in), Height (ft), Volume(ft^3)",
                "1,   8.3,     70,   10.3",
                "2,   8.6,     65,   19.3"
            };

            var expected = 19.3;
            
            var dataitems = from row in inpdata
                let data = row.Split(',')
                select new DataItem
                (
                    data[0],
                    data[1],
                    data[2],
                    data[3]
                );

            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateLargest(input, dataitems);

            // Assert
            actual.Should().BeGreaterOrEqualTo(expected);
        }
    }
}