namespace AdventOfCode2020.Traveling.Boarding
{
    public struct SeatInfo
    {
        public SeatInfo(int id, int row, int column)
        {
            Id = id;
            Row = row;
            Column = column;
        }

        public int Id { get; }
        public int Row { get; }
        public int Column { get; }
    }
}
