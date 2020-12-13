using AdventOfCode2020.Gaming;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2020.Day8
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
            var accumulator = new Accumulator(_input);
            accumulator.Run();

            _output.WriteLine($"Soluton: {accumulator.Value} is the value of accumulator.");
            Assert.Equal(1217, accumulator.Value);
        }


        [Fact]
        public void Part2()
        {
            for (var i = 0; i < _input.Length; i++)
            {
                var input = _input
                    .Select((line, ix) =>
                    {
                        if (ix == i)
                        {
                            return (line.Substring(0, 3)) switch
                            {
                                "nop" => line.Replace("nop", "jmp"),
                                "jmp" => line.Replace("jmp", "nop"),
                                _ => line,
                            };
                        }
                        else
                        {
                            return line;
                        }
                    })
                    .ToArray();

                var accumulator = new Accumulator(input);
                accumulator.Run();

                if (accumulator.Terminated)
                {
                    _output.WriteLine($"Soluton: {accumulator.Value} is the value of accumulator.");
                    Assert.Equal(501, accumulator.Value);
                    return;
                }
            }
        }
    }
}
