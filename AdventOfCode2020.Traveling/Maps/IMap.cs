namespace AdventOfCode2020.Traveling.Maps
{
    public interface IMap
    {
        int Height { get; }

        bool IsTree(int x, int y);
    }
}