namespace GameOfLife
{
    public interface IGrid
    {
        bool[,] CurrentState();

        void Tick();
    }
}
