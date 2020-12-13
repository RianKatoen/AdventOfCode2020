using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Gaming
{
    public class Accumulator
    {
        public int Line { get; private set; } = 0;
        public int Value { get; private set; } = 0;
        public bool Terminated { get; private set; } = false;

        public readonly List<Instruction> _memory = new List<Instruction>();
        public IReadOnlyList<Instruction> Memory => _memory;

        public Accumulator(IEnumerable<string> instructions)
        {
            foreach (var instruction in instructions)
            {
                var regexGroups = Regex
                    .Match(instruction, @"([a-z]+) ([\+|\-{1}]\d+)", RegexOptions.Compiled)
                    .Groups;

                var operation = Enum.Parse<Operation>(regexGroups[1].Value);
                var argument = int.Parse(regexGroups[2].Value);

                _memory.Add(new Instruction(operation, argument));
            }
        }

        public void RunLine()
        {
            if (!Terminated)
            {
                var instruction = _memory[Line];
                switch (instruction.Operation)
                {
                    case Operation.jmp:
                        Line += instruction.Argument;
                        break;
                    case Operation.acc:
                        Value += instruction.Argument;
                        Line++;
                        break;
                    default:
                        Line++;
                        break;
                }

                if (Line >= Memory.Count)
                {
                    Terminated = true;
                }
            }
        }

        public void Run()
        {
            var visitedLines = new bool[Memory.Count];
            while (!Terminated && !visitedLines[Line])
            {
                visitedLines[Line] = true;
                RunLine();
            }
        }
    }
}
