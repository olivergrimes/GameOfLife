namespace GameOfLife
{
    public class Grid : IGrid
    {
        private bool[,] _currentState;

        public Grid(bool[,] initialState)
        {
            _currentState = initialState;
        }

        public bool[,] CurrentState() => _currentState;

        public void Tick()
        {
            var xLen = _currentState.GetUpperBound(0);
            var yLen = _currentState.GetUpperBound(1);
            var nextState = new bool[xLen + 1, yLen + 1];

            for (int x = 0; x <= xLen; x++)
            {
                for (int y = 0; y <= yLen; y++)
                {
                    var neighbourState = new NeighbourState(_currentState, x, y);
                    var cell = new Cell(_currentState[x, y], neighbourState);

                    nextState[x, y] = cell.GetNextState();
                }
            }

            _currentState = nextState;
        }
    }
}
