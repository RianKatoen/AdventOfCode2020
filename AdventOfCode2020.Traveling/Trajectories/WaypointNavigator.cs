using System.Collections.Generic;

namespace AdventOfCode2020.Traveling.Trajectories
{
    public class WaypointNavigator
    {
        public int East { get; private set; } = 10;
        public int North { get; private set; } = 1;
        public char Direction { get; private set; } = 'E';

        public int PositionEast { get; private set; } = 0;
        public int PositionNorth { get; private set; } = 0;

        public void TurnClockwise(int times)
        {
            if (times > 0)
            {
                var nTurns = 0;
                while (nTurns < times)
                {
                    var east = East;
                    var north = North;

                    North = -east;
                    East = north;

                    nTurns++;
                }
            }
            else
            {
                var nTurns = 0;
                while (nTurns < -times)
                {
                    var east = East;
                    var north = North;

                    North = east;
                    East = -north;

                    nTurns++;
                }
            }
        }

        public void Action(string instruction)
        {
            var action = instruction[0];
            var value = int.Parse(instruction.Substring(1));

            switch (action)
            {
                case 'N':
                    North += value;
                    break;
                case 'S':
                    North -= value;
                    break;
                case 'E':
                    East += value;
                    break;
                case 'W':
                    East -= value;
                    break;
                case 'L':
                    TurnClockwise(-value / 90);
                    break;
                case 'R':
                    TurnClockwise(value / 90);
                    break;
                case 'F':
                    PositionEast += value * East;
                    PositionNorth += value * North;
                    break;
                default:
                    break;
            }
        }

        public void Navigate(IEnumerable<string> instructions)
        {
            foreach (var instruction in instructions)
            {
                Action(instruction);
            }
        }
    }
}
