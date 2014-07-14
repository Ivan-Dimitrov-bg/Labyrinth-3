namespace Labyrinth.Interfaces
{
    using Labyrinth.GameObjects;

    public interface IMaze : IRenderable
    {
        int Rows { get; }

        int Cols { get; }

        Position PlayerPosition { get; }

        ICell this[int row, int col] { get; set; }
    }
}