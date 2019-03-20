using System.Linq;
using ExternalFeedConverter.Core.Data;
using ExternalFeedConverter.Core.Output;
using Xunit;


namespace ExternalFeedConverter.Core.Test
{
    public class OutputWriterTests
    {
        [Fact]
        public static void Should_Output_WhenDataIsValid()
        {
            // Arrange
            var inpdata = new[]
            {
                "1,   8.3,     70,   10.3",
                "2,   8.6,     65,   10.3"
            };

            var dataitems = from row in inpdata
                let data = row.Split(',')
                select new DataItem
                (
                    data[0],
                    data[1],
                    data[2],
                    data[3]
                );

            var sut = new OutputWriter();

            // Act
            sut.PrintTable(dataitems);
            // Assert
        }
    }
}