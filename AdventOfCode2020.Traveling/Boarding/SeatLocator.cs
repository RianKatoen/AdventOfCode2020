namespace AdventOfCode2020.Traveling.Boarding
{
    public class SeatLocator
    {
        private readonly int _noRowPartitions;
        private readonly int _noColumnPartitions;

        public SeatLocator(int noRowPartitions = 7, int noColumnPartitions = 3)
        {
            _noRowPartitions = noRowPartitions;
            _noColumnPartitions = noColumnPartitions;
        }

        public SeatInfo GetSeatInfo(string code)
        {
            if (code.Length == _noRowPartitions + _noColumnPartitions)
            {
                var row = 0;
                for (var i = 0; i < _noRowPartitions; i++)
                {
                    switch (code[i])
                    {
                        case 'B': row += 1 << (_noRowPartitions - 1 - i); break;
                        case 'F': break;
                        default: return new SeatInfo(-1, -1, -1);
                    }
                }

                var column = 0;
                for (var i = _noRowPartitions; i < code.Length; i++)
                {
                    switch (code[i])
                    {
                        case 'R': column += 1 << (_noColumnPartitions + _noRowPartitions - 1 - i); break;
                        case 'L': break;
                        default: return new SeatInfo(-1, -1, -1);
                    }
                }

                return new SeatInfo(
                    id: row * (_noRowPartitions + 1) + column,
                    row: row,
                    column: column);
            }

            return new SeatInfo(-1, -1, -1);
        }
    }
}
