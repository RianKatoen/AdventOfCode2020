using Xunit;

namespace AdventOfCode2020.Gaming.Tests
{
    public class AccumulatorTests
    {
        private readonly string[] _instructions = new string[]
        {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
        };

        [Fact]
        public void Example()
        {
            var sut = new Accumulator(_instructions);

            // Initial checks.
            Assert.Equal(0, sut.Line);
            Assert.Equal(0, sut.Value);
            Assert.Equal(9, sut.Memory.Count);
            Assert.Equal(new Instruction(Operation.nop, 0), sut.Memory[0]);
            Assert.Equal(new Instruction(Operation.jmp, 4), sut.Memory[2]);
            Assert.Equal(new Instruction(Operation.acc, -99), sut.Memory[5]);
            Assert.Equal(new Instruction(Operation.acc, 6), sut.Memory[8]);

            // First line.
            sut.RunLine();
            Assert.Equal(1, sut.Line);
            Assert.Equal(0, sut.Value);

            // Next line.
            sut.RunLine();
            Assert.Equal(2, sut.Line);
            Assert.Equal(1, sut.Value);

            // Next line.
            sut.RunLine();
            Assert.Equal(6, sut.Line);
            Assert.Equal(1, sut.Value);

            // Next line.
            sut.RunLine();
            Assert.Equal(7, sut.Line);
            Assert.Equal(2, sut.Value);
            
            // Next line.
            sut.RunLine();
            Assert.Equal(3, sut.Line);
            Assert.Equal(2, sut.Value);

            // Next line.
            sut.RunLine();
            Assert.Equal(4, sut.Line);
            Assert.Equal(5, sut.Value);

            // Next line.
            sut.RunLine();
            Assert.Equal(1, sut.Line);
            Assert.Equal(5, sut.Value);
        }
    }
}
