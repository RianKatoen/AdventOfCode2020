using Xunit;

namespace AdventOfCode2020.Expenses.Tests
{
    public class ReportGeneratorTests
    {
        [Theory]
        [InlineData(1008, 1008)]
        [InlineData(1009, 1011)]
        [InlineData(1009, 1013)]
        [InlineData(1013, 1013)]
        public void FindPair_Should_FindProduct(int valueA, int valueB)
        {
            var report = new int[] { 1008, 1009, 1010, 1011, 1013 };
            var sut = new ReportGenerator();

            Assert.Equal(valueA * valueB, sut.FindPair(report, valueA + valueB));
        }

        [Theory]
        [InlineData(1008, 1008, 1010)]
        [InlineData(1009, 1010, 1015)]
        [InlineData(1009, 1015, 1008)]
        [InlineData(1111, 1111, 1111)]
        public void FindTriplet_Should_FindProduct(int valueA, int valueB, int valueC)
        {
            var report = new int[] { 1008, 1009, 1010, 1015, 1111 };
            var sut = new ReportGenerator();

            Assert.Equal(valueA * valueB * valueC, sut.FindTriplet(report, valueA + valueB + valueC));
        }
    }
}
