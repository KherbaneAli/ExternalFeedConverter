using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExternalFeedConverter.Core.Calculator;
using ExternalFeedConverter.Core.Data;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ExternalFeedConverter.Core.Test
{
    public class CalculatorTests
    {
        [Fact]
        public static void Should_Calculate_ReturnMaxValueForAttribute_WhenInputIsValid()
        {
            // Arrange
            var input = "girth";
            var expected = 30.2;
            
            var rows = new[]
            {
                "1", "30.2", "70", "20",
                "2", "20.2", "60", "40"
            };
            
            var dataitems = from row in rows
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
            actual.Should().BeLessOrEqualTo(expected);
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