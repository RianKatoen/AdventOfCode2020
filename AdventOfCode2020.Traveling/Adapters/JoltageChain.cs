using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Traveling.Adapters
{
    public class JoltageChain
    {
        private readonly int[] _adapters;
        private readonly int[] _joltageDeltas;
        private readonly int _lastAdapter;

        public JoltageChain(IEnumerable<int> adapters)
        {
            _adapters = adapters
                .Prepend(0)
                .OrderBy(joltage => joltage)
                .ToArray();

            _lastAdapter = _adapters.Last() + 3;

            _adapters = _adapters
                .Append(_lastAdapter)
                .ToArray();

            _joltageDeltas = new int[_adapters.Length - 1];
            for (var i = 0; i < _joltageDeltas.Length; i++)
            {
                var joltageDifference = _adapters[i + 1] - _adapters[i];
                if (joltageDifference < 1 || joltageDifference > 3)
                {
                    throw new ArgumentException($"Joltage delta of {joltageDifference} between " +
                        $"adapters {_adapters[i + 1]} and {_adapters[i]}");
                }
                else
                {
                    _joltageDeltas[i] = joltageDifference;
                }
            }
        }

        public int NoJoltageDeltas(int joltageDelta)
            => _joltageDeltas.Count(jd => jd == joltageDelta);

        public long NoDistinctChains()
        {
            var noDistinctChains = new long[_adapters.Length];
            
            noDistinctChains[noDistinctChains.Length - 1] = 1;
            for (var i = noDistinctChains.Length - 2; i >= 0; i--)
            {
                for (var j = i + 1; j <= j + 3; j++)
                {
                    if (j < noDistinctChains.Length && _adapters[j] - _adapters[i] <= 3)
                    {
                        noDistinctChains[i] += noDistinctChains[j];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return noDistinctChains[0];

            //if (startIndex >= _joltageDeltas.Length - 1)
            //{
            //    return 0;
            //}
            //if (startIndex == _joltageDeltas.Length - 2)
            //{
            //    return 1;
            //}
            //else
            //{
            //    long distinctChains = 0;
            //    int joltageDelta = 0;
            //    for (var i = startIndex + 1; i <= startIndex + 3; i++)
            //    {
            //        joltageDelta += _joltageDeltas[i];
            //        if (i < _joltageDeltas.Length - 1 && joltageDelta <= 3)
            //        {
            //            distinctChains += NoDistinctChains(i);
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }

            //    return distinctChains;
            //}
        }
    }
}
