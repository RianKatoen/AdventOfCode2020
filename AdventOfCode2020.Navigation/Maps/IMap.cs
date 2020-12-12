namespace AdventOfCode2020.Navigation.Maps
{
    public interface IMap
    {
        int Height { get; }

        bool IsTree(int x, int y);
    }
}