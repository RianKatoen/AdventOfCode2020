using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Traveling.Waiting
{
    public class Seat
    {
        public Seat(SeatState state)
        {
            State = state;
            NeighbouringSeats = new List<Seat>();
        }

        public Seat(SeatState state, int occupanceThreashold)
        {
            OccupanceThreashold = occupanceThreashold;
            State = state;
            NeighbouringSeats = new List<Seat>();
        }

        public Seat(SeatState state, IEnumerable<Seat> seats)
        {
            State = state;
            NeighbouringSeats = seats.ToList();
        }

        private SeatState? _nextState = SeatState.Empty;
        public int OccupanceThreashold { get; private set; } = 4;
        public SeatState State { get; private set; }
        public List<Seat> NeighbouringSeats { get; }

        public int CalculateNextState()
        {
            if (State == SeatState.Empty && NeighbouringSeats.All(s => s.State == SeatState.Empty))
            {
                _nextState = SeatState.Occupied;
                return 1;
            }
            else if (State == SeatState.Occupied)
            {
                var noOccupiedNeighbours = 0;
                foreach (var neighbouringSeat in NeighbouringSeats)
                {
                    noOccupiedNeighbours += neighbouringSeat.State == SeatState.Occupied ? 1 : 0;
                    if (noOccupiedNeighbours >= OccupanceThreashold)
                    {
                        _nextState = SeatState.Empty;
                        return 1;
                    }
                }
            }

            _nextState = State;
            return 0;
        }

        public void ApplyNextState()
        {
            if (_nextState.HasValue)
            {
                State = _nextState.Value;
                _nextState = null;
            }
            else
            {
                throw new System.InvalidOperationException($"{nameof(CalculateNextState)} has not been called yet.");
            }
        }

        public override string ToString()
        {
            return State == SeatState.Empty ? "L" : "#";
        }
    }
}
