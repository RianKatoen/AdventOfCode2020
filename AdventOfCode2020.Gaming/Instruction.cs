namespace AdventOfCode2020.Gaming
{
    public struct Instruction
    {
        public Instruction(Operation op, int arg)
        {
            Operation = op;
            Argument = arg;
        }

        public Operation Operation { get; }
        public int Argument { get; }
    }
}
