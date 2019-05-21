using FluentAssertions;
using ExternalFeedConverter.Core.Extensions;
using Xunit;

namespace ExternalFeedConverter.Core.Test
{
    public static class StringExtensionsTests
    {
        [Fact]
        public static void Should_Capitalise_ReturnsStringWithFirstLetterUpperOnly_WhenInputIsMixedCase()
        {
            // Arrange
            var input = "hElLO";
            var expected = "Hello";

            // Act
            var actual = input.ToCapitalCase();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public static void Should_Capitalise_ReturnsStringWithFirstLetterUpperOnly_WhenInputIsLowerCase()
        {
            // Arrange
            var input = "index";
            var expected = "Index";

            // Act
            var actual = input.ToCapitalCase();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public static void Should_Capitalise_ReturnsStringWithFirstLetterUpperOnly_WhenInputIsUpperCase()
        {
            // Arrange
            var input = "UPPERCASE";
            var expected = "Uppercase";

            // Act
            var actual = input.ToCapitalCase();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public static void Should_Capitalise_ReturnsEmptyString_WhenInputContainsNoCharacters()
        {
            // Arrange
            var input = "";
            var expected = "";

            // Act
            var actual = input.ToCapitalCase();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public static void Should_Parse_ReturnsStringAsInt_WhenInputCanBeParsed()
        {
            // Arrange
            var input = "42";

            // Act
            var actual = input.ToInt();

            // Assert
            actual.Should().BeOfType(typeof(int));
        }

        [Fact]
        public static void Should_Parse_ReturnsStringAsDouble_WhenInputCanBeParsed()
        {
            // Arrange
            var input = "42.3";

            // Act
            var actual = input.ToDouble();

            // Assert
            actual.Should().BeOfType(typeof(double));
        }

        [Fact]
        public static void Should_Parse_Returns0_WhenInputCanNotBeParsed()
        {
            // Arrange
            var input = "forty-two";
            var expected = 0;

            // Act
            var actual = input.ToDouble();

            // Assert
            actual.Should().BeLessOrEqualTo(expected);
        }

        [Fact]
        public static void Should_Parse_ReturnsStringAsBoolean_WhenInputCanBeParsedTrue()
        {
            // Arrange
            var input = "True";

            // Act
            var actual = input.ToBoolean();

            // Assert
            actual.Should().Be(true);
        }

        [Fact]
        public static void Should_Parse_ReturnsStringAsBoolean_WhenInputCanBeParsedFalse()
        {
            // Arrange
            var input = "False";

            // Act
            var actual = input.ToBoolean();

            // Assert
            actual.Should().Be(false);
        }
    }
}