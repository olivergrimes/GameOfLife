using System;

namespace GameOfLife
{
    public class NeighbourState : INeighbourState
    {
        private readonly bool[,] _currentState;
        private readonly int _x;
        private readonly int _y;

        public NeighbourState(bool[,] currentState, int x, int y)
        {
            _currentState = currentState ?? throw new ArgumentNullException(nameof(currentState));
            _x = x;
            _y = y;
        }

        public int AliveNeighbours()
        {
            var aliveCount = 0;

            aliveCount += IsAlive(-1, 0);
            aliveCount += IsAlive(-1, -1);
            aliveCount += IsAlive(-1, 1);
            aliveCount += IsAlive(0, -1);
            aliveCount += IsAlive(0, 1);
            aliveCount += IsAlive(1, 0);
            aliveCount += IsAlive(1, -1);
            aliveCount += IsAlive(1, 1);

            return aliveCount;
        }

        private int IsAlive(int offsetX, int offsetY)
        {
            var x = _x + offsetX;
            var y = _y + offsetY;

            if (x < _currentState.GetLowerBound(0) || x > _currentState.GetUpperBound(0) ||
                y < _currentState.GetLowerBound(1) || y > _currentState.GetUpperBound(1))
            {
                return 0;
            }

            return _currentState[x, y] ? 1 : 0;
        }
    }
}
