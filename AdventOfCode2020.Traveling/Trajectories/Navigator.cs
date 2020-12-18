using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Traveling.Trajectories
{
    public class Navigator
    {
        public int East { get; private set; } = 0;
        public int North { get; private set; } = 0;
        public char Direction { get; private set; } = 'E';

        public void TurnClockwise(int times)
        {
            if (times > 0)
            {
                var nTurns = 0;
                while (nTurns < times)
                {
                    switch (Direction)
                    {
                        case 'N':
                            Direction = 'E';
                            break;
                        case 'S':
                            Direction = 'W';
                            break;
                        case 'E':
                            Direction = 'S';
                            break;
                        case 'W':
                            Direction = 'N';
                            break;
                    }

                    nTurns++;
                }
            }
            else
            {
                var nTurns = 0;
                times = Math.Abs(times);
                while (nTurns < times)
                {
                    switch (Direction)
                    {
                        case 'N':
                            Direction = 'W';
                            break;
                        case 'S':
                            Direction = 'E';
                            break;
                        case 'E':
                            Direction = 'N';
                            break;
                        case 'W':
                            Direction = 'S';
                            break;
                    }

                    nTurns++;
                }
            }
        }

        public int Action(string instruction)
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
                    return 0;
                case 'R':
                    TurnClockwise(value / 90);
                    return 0;
                case 'F':
                    Action($"{Direction}{value}");
                    break;
                default:
                    return -1;
            }

            return value;
        }

        public int Navigate(IEnumerable<string> instructions)
        {
            var distance = 0;
            foreach (var instruction in instructions)
            {
                distance += Action(instruction);
            }
            return distance;
        }
    }
}
