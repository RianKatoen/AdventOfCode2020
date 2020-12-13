using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Security.Encryption
{
    public class Xmas
    {
        public Xmas(int preambleSize, IEnumerable<long> data)
        {
            PreambleSize = preambleSize;
            _data = data.ToList();
        }

        public int PreambleSize { get; }

        private readonly List<long> _data;
        public IReadOnlyList<long> Data => _data;

        public IEnumerable<long> InvalidEntries()
        {
            var ix = PreambleSize;
            while (ix < _data.Count)
            {
                var currentEntry = _data[ix];
                for (var i = ix - PreambleSize; i < ix; i++)
                {
                    for (var j = i + 1; j < ix; j++)
                    {
                        if (currentEntry == _data[i] + _data[j])
                        {
                            goto ValidEnty;
                        }
                    }
                }

                yield return currentEntry;

            ValidEnty:
                ix++;
            }
        }

        public IEnumerable<IList<long>> ContiguousRanges(long target)
        {
            var startIx = 0;
            var endIx = 1;
            var sum = _data[startIx] + _data[endIx];

            while (endIx < _data.Count && startIx < Data.Count - 1)
            {
                if (startIx == endIx || sum < target)
                {
                    sum += _data[++endIx];
                }
                else if (sum >= target)
                {
                    if (sum == target)
                    {
                        yield return _data.GetRange(startIx, endIx - startIx + 1);
                        startIx++;
                    }

                    sum -= _data[startIx++];
                }
            }
        }
    }
}
