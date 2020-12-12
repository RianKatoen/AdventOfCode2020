using AdventOfCode2020.Traveling.Customs;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day6
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        private readonly string[] _input = File.ReadAllLines("Input.txt");
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Part1()
        {
            var questionnaireHandler = new QuestionnaireHandler();
            var noYes = questionnaireHandler
                .HandleData(_input)
                .Select(a => questionnaireHandler.Count(a))
                .Sum();

            _output.WriteLine($"Soluton: {noYes} is total number of 'yes'.");
            Assert.Equal(6585, noYes);
        }

        [Fact]
        public void Part2()
        {
            var questionnaireHandler = new QuestionnaireHandler();
            var noYes = questionnaireHandler
                .HandleData(_input, true)
                .Select(a => questionnaireHandler.Count(a))
                .Sum();

            _output.WriteLine($"Soluton: {noYes} is total number of 'yes'.");
            Assert.Equal(3276, noYes);
        }
    }
}
