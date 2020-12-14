using AdventOfCode2020.Traveling.Adapters;
using Xunit;

namespace AdventOfCode2020.Traveling.Tests.Adapters
{
    public class JoltageChainTests
    {
        [Fact]
        public void Example()
        {
            var data = new int[]
            {
                28,
                33,
                18,
                42,
                31,
                14,
                46,
                20,
                48,
                47,
                24,
                23,
                49,
                45,
                19,
                38,
                39,
                11,
                1,
                32,
                25,
                35,
                8,
                17,
                7,
                9,
                4,
                2,
                34,
                10,
                3
            };

            var sut = new JoltageChain(data);

            Assert.Equal(22, sut.NoJoltageDeltas(1));
            Assert.Equal(10, sut.NoJoltageDeltas(3));

            Assert.Equal(19208, sut.NoDistinctChains());
        }
    }
}
