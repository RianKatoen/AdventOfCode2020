using System;
using System.Linq;

namespace AdventOfCode2020.Traveling.Maps
{
    public class Map : IMap
    {
        private readonly int _mapWidth;
        private readonly bool[,] _map;

        public int Height { get; set; }

        public Map(string[] lines)
        {
            var mapWidths = lines
                .Select(l => l.Length)
                .Distinct()
                .ToArray();

            if (mapWidths.Length == 1)
            {
                _mapWidth = mapWidths.First();
                Height = lines.Count();

                _map = new bool[_mapWidth, Height];

                var y = 0;
                foreach (var line in lines)
                {
                    var x = 0;
                    foreach (var character in line)
                    {
                        _map[x, y] = character == '#';
                        x++;
                    }
                    y++;
                }
            }
            else
            {
                throw new ArgumentException("Provided map is not of rectangle size.");
            }
        }

        public bool IsTree(int x, int y) => _map[x % _mapWidth, y];
    }
}
