using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExternalFeedConverter.Core.Calculator;
using ExternalFeedConverter.Core.Data;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using NSubstitute;
using Xunit;

namespace ExternalFeedConverter.Core.Test
{
    public class CalculatorTests
    {
        [Fact]
        public static void Should_Calculate_ReturnMaxValueForGirth_WhenInputIsValid()
        {
            // Arrange
            var input = "Girth";
            var inpdata = new[]
            {
                "Index, Girth (in), Height (ft), Volume(ft^3)",
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

            var commandValues = new List<CommandValue>();
            
            var sut = new Calculator.Calculator(commandValues);
            
            // Act
            var actual = sut.ReturnLargest(input, dataitems);
            
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

            var commandValues = new List<CommandValue>();
            
            var sut = new Calculator.Calculator(commandValues);
            
            // Act
            var actual = sut.ReturnLargest(input, dataitems);
            
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

            var commandValues = new List<CommandValue>();
            
            var sut = new Calculator.Calculator(commandValues);
            
            // Act
            var actual = sut.ReturnLargest(input, dataitems);
            
            // Assert
            actual.Should().BeGreaterOrEqualTo(expected);
        }        
        
        /*[Fact]
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
        }*/
    }
}