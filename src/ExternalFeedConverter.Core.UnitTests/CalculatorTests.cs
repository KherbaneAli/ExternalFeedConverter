using System.Collections.Generic;
using System.Linq;
using ExternalFeedConverter.Core.Calculator;
using ExternalFeedConverter.Core.Data;
using ExternalFeedConverter.Core.Extensions;
using FluentAssertions;
using Xunit;

namespace ExternalFeedConverter.Core.Test
{
    public class CalculatorTests
    {
        public static List<CommandValue> commandValues = new List<CommandValue>();
        
        [Fact]
        public static void Should_Calculate_ReturnAvgValueForGirth_WhenInputIsValid()
        {
            // Arrange
            var input = "Girth";
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 8.45;
            
            var dataitems = from row in inpdata
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

            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input,"Avg", dataitems);

            // Assert
            actual.Should().Be(expected);

        }

        [Fact]
        public static void Should_Calculate_ReturnAvgValueForHeight_WhenInputIsValid()
        {
            // Arrange
            var input = "Height";
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 67.5;
            
            var dataitems = from row in inpdata
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
            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input,"Avg",dataitems);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public static void Should_Calculate_ReturnAvgValueForVolume_WhenInputIsValid()
        {
            // Arrange
            var input = "Volume";
            var inpdata = new[]
            {
                "1,   8.3,     70,   19.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 14.8;
            
            var dataitems = from row in inpdata
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

            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input, "Avg", dataitems);

            // Assert
            actual.Should().Be(expected);
        }
        [Fact]
        public static void Should_Calculate_ReturnMaxValueForGirth_WhenInputIsValid()
        {
            // Arrange
            var input = "Girth";
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 8.6;
            
            var dataitems = from row in inpdata
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

            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input,"Max", dataitems);

            // Assert
            actual.Should().Be(expected);

        }

        [Fact]
        public static void Should_Calculate_ReturnMaxValueForHeight_WhenInputIsValid()
        {
            // Arrange
            var input = "Height";
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 70;
            
            var dataitems = from row in inpdata
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
            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input,"Max",dataitems);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public static void Should_Calculate_ReturnMaxValueForVolume_WhenInputIsValid()
        {
            // Arrange
            var input = "Volume";
            var inpdata = new[]
            {
                "1,   8.3,     70,   19.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 19.3;
            
            var dataitems = from row in inpdata
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

            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input, "Max", dataitems);

            // Assert
            actual.Should().Be(expected);
        }
        [Fact]
         public static void Should_Calculate_ReturnMinValueForGirth_WhenInputIsValid()
        {
            // Arrange
            var input = "Girth";
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 8.3;
            
            var dataitems = from row in inpdata
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

            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input,"Min", dataitems);

            // Assert
            actual.Should().Be(expected);

        }

        [Fact]
        public static void Should_Calculate_ReturnMinValueForHeight_WhenInputIsValid()
        {
            // Arrange
            var input = "Height";
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 65;
            
            var dataitems = from row in inpdata
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
            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input,"Min",dataitems);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public static void Should_Calculate_ReturnMinValueForVolume_WhenInputIsValid()
        {
            // Arrange
            var input = "Volume";
            var inpdata = new[]
            {
                "1,   8.3,     70,   19.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 10.3;
            
            var dataitems = from row in inpdata
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

            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input, "Min", dataitems);

            // Assert
            actual.Should().Be(expected);
            
        }
                [Fact]
        public static void Should_Calculate_ReturnSumValueForGirth_WhenInputIsValid()
        {
            // Arrange
            var input = "Girth";
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 16.9;
            
            var dataitems = from row in inpdata
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

            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input,"Sum", dataitems);

            // Assert
            actual.Should().Be(expected);

        }

        [Fact]
        public static void Should_Calculate_ReturnSumValueForHeight_WhenInputIsValid()
        {
            // Arrange
            var input = "Height";
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 135;
            
            var dataitems = from row in inpdata
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
            
            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input,"Sum",dataitems);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public static void Should_Calculate_ReturnSumValueForVolume_WhenInputIsValid()
        {
            // Arrange
            var input = "Volume";
            var inpdata = new[]
            {
                "1,   8.3,     70,   19.3,    Willow,    True",
                "2,   8.6,     65,   10.3,    Oak,    True"
            };

            var expected = 29.6;
            
            var dataitems = from row in inpdata
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

            var sut = new Calculator.Calculator(commandValues);

            // Act
            var actual = sut.CalculateValue(input, "Sum", dataitems);

            // Assert
            actual.Should().Be(expected);
        }
    }
}