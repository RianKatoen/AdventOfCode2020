using AdventOfCode2020.Security.Encryption;
using Xunit;

namespace AdventOfCode2020.Security.Tests.Encryption
{
    public class XmasTests
    {
        [Fact]
        public void Example1()
        {
            var data = new long[]
            {
                35,
                20,
                15,
                25,
                47,
                40,
                62,
                55,
                65,
                95,
                102,
                117,
                150,
                182,
                127,
                219,
                299,
                277,
                309,
                576
            };

            var sut = new Xmas(5, data);

            var invalidEntry = Assert.Single(sut.InvalidEntries());
            Assert.Equal(127, invalidEntry);
        }

        [Fact]
        public void Example2()
        {
            var data = new long[]
            {
                35,
                20,
                15,
                25,
                47,
                40,
                62,
                55,
                65,
                95,
                102,
                117,
                150,
                182,
                127,
                219,
                299,
                277,
                309,
                576
            };

            var sut = new Xmas(5, data);

            var contiguousRange = Assert.Single(sut.ContiguousRanges(127));
            Assert.Equal(15, contiguousRange[0]);
            Assert.Equal(25, contiguousRange[1]);
            Assert.Equal(47, contiguousRange[2]);
            Assert.Equal(40, contiguousRange[3]);
        }
    }
}
