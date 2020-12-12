using AdventOfCode2020.Traveling.Maps;

namespace AdventOfCode2020.Traveling.Trajectories
{
    public class TrajectoryCalculator
    {
        public int NumberOfTrees(IMap map, int angleX, int angleY)
        {
            if (angleX % angleY == 0)
            {
                angleX = angleX / angleY;
                angleY = 1;
            }
            else if (angleY % angleX == 0)
            {
                angleX = 1;
                angleY = angleY / angleX;
            }

            var noTrees = 0;
            var x = 0;
            var y = 0;
            while (y < map.Height)
            {
                noTrees += map.IsTree(x, y) ? 1 : 0;
                x += angleX;
                y += angleY;
            }

            return noTrees;
        }
    }
}
