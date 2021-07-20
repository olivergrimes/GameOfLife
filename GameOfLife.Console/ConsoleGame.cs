using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace GameOfLife.Console
{
    public class ConsoleGame
    {
        private readonly int _delayMs;
        private readonly IGrid _grid;

        public ConsoleGame(
            IGrid grid,
            int delayMs = 1000)
        {
            _grid = grid ?? throw new ArgumentNullException(nameof(grid));
            _delayMs = delayMs;
        }

        public async Task RunSimulation(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                SetCursorPosition(0, 0);

                var currentState = _grid.CurrentState();

                for (int x = 0; x <= currentState.GetUpperBound(0); x++)
                {
                    var row = new StringBuilder();

                    for (int y = 0; y <= currentState.GetUpperBound(1); y++)
                    {
                        row.Append(currentState[x, y] ? "■" : "o");
                    }

                    WriteLine(row);
                }

                _grid.Tick();
                await Task.Delay(_delayMs);
            }
        }
    }
}
