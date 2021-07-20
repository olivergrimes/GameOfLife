using System;
using System.Threading;
using static System.Console;

namespace GameOfLife.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var xLen = 40;
            var yLen = 170;
            var initialState = new bool[xLen, yLen];
            var rand = new Random();
            var half = (xLen * yLen / 2);

            for (int i = 0; i < half; i++)
            {
                var x = rand.Next(0, xLen);
                var y = rand.Next(0, yLen);

                initialState[x, y] = true;
            }

            var cts = new CancellationTokenSource();
            var game = new ConsoleGame(new Grid(initialState), 10);
            SetWindowSize(yLen + 1, xLen + 1);

            _ = game.RunSimulation(cts.Token);

            ReadLine();
            cts.Cancel();
        }
    }
}
