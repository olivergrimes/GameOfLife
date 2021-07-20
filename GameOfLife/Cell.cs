using System;

namespace GameOfLife
{
    public class Cell
    {
        private readonly INeighbourState _neighbourState;
        private bool _isAlive;

        public Cell(bool initialState, INeighbourState neighbourState)
        {
            _isAlive = initialState;
            _neighbourState = neighbourState ?? throw new ArgumentNullException(nameof(neighbourState));
        }

        public bool GetCurrentState() => _isAlive;

        public bool GetNextState()
        {
            var aliveNeighbours = _neighbourState.AliveNeighbours();

            if (_isAlive && aliveNeighbours >= 2 && aliveNeighbours <= 3)
            {
                return true;
            }
            else if (!_isAlive && aliveNeighbours == 3)
            {
                return true;
            }

            return false;
        }
    }
}
