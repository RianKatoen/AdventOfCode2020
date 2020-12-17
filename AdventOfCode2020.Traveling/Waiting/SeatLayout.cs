using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Traveling.Waiting
{
    public class SeatLayout
    {
        private readonly int _nRows;
        private readonly int _nCols;
        private readonly Seat[,] _seatLayout;
        private readonly List<Seat> _seats = new List<Seat>();

        public Seat this[int row, int col]
            => _seatLayout[row, col];

        public int NoOccupiedSeats()
            => _seats.Where(s => s.State == SeatState.Occupied).Count();

        public int Tick()
        {
            var noStateSwitches = 0;
            foreach (var seat in _seats)
            {
                noStateSwitches += seat.CalculateNextState();
            }

            foreach (var seat in _seats)
            {
                seat.ApplyNextState();
            }

            return noStateSwitches;
        }

        public SeatLayout(IEnumerable<string> seats, bool useLineOfSight = false)
        {
            var seatArray = seats.ToArray();

            _nRows = seatArray.Length;
            _nCols = seatArray.Select(s => s.Length).Max();
            _seatLayout = new Seat[_nRows, _nCols];

            for (var i = 0; i < _nRows; i++)
            {
                var j = 0;
                foreach (var character in seatArray[i])
                {
                    switch (character)
                    {
                        case 'L':
                            _seatLayout[i, j] = new Seat(SeatState.Empty, useLineOfSight ? 5 : 4);
                            break;
                        case '#':
                            _seatLayout[i, j] = new Seat(SeatState.Occupied, useLineOfSight ? 5 : 4);
                            break;
                        default:
                            break;
                    }

                    j++;
                }
            }


            for (var i = 0; i < _nRows; i++)
            {
                for (var j = 0; j < _nCols; j++)
                {
                    var seat = _seatLayout[i, j];

                    if (seat != null)
                    {

                        _seats.Add(seat);
                        if (!useLineOfSight)
                        {
                            for (var n = Math.Max(0, i - 1); n <= Math.Min(_nRows - 1, i + 1); n++)
                            {
                                for (var m = Math.Max(0, j - 1); m <= Math.Min(_nCols - 1, j + 1); m++)
                                {
                                    var neighbouringSeat = _seatLayout[n, m];
                                    if (!(i == n && j == m) && neighbouringSeat != null)
                                    {
                                        seat.NeighbouringSeats.Add(neighbouringSeat);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (var deltaN = -1; deltaN <= 1; deltaN++)
                            {
                                for (var deltaM = -1; deltaM <= 1; deltaM++)
                                {
                                    if (deltaN == 0 && deltaM == 0)
                                        continue;

                                    var row = i + deltaN;
                                    var col = j + deltaM;

                                    while (row >= 0 && row < _nRows
                                        && col >= 0 && col < _nCols)
                                    {
                                        var neighbouringSeat = _seatLayout[row, col];
                                        if (neighbouringSeat != null)
                                        {
                                            seat.NeighbouringSeats.Add(neighbouringSeat);
                                            row = -1;
                                            col = -1;
                                        }
                                        else
                                        {
                                            row += deltaN;
                                            col += deltaM;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}