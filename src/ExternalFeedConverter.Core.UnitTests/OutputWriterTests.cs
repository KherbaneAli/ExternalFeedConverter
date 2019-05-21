using System.Linq;
using ExternalFeedConverter.Core.Data;
using ExternalFeedConverter.Core.Extensions;
using ExternalFeedConverter.Core.Output;
using Xunit;


namespace ExternalFeedConverter.Core.Test
{
    public static class OutputWriterTests
    {
        [Fact]
        public static void Should_Output_WhenDataIsValid()
        {
            // Arrange
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3, Willow, True",
                "2,   8.6,     65,   10.3, Oak, False"
            };

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

            var sut = new OutputWriter();

            // Act
            sut.PrintTable(dataitems);
            // Assert
        }
    }
}