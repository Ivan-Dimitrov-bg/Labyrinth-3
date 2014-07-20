namespace Labyrinth.Interfaces
{
    using Labyrinth.GameObjects;

    /// <summary>
    /// Inherits the IRenderable inrerface
    /// <remarks>
    /// Creates the maze interface with appropriate getters and setters accordingly
    /// </remarks>
    /// </summary>
    public interface IMaze : IRenderable
    {
        int Rows { get; }

        int Cols { get; }

        Position PlayerPosition { get; }

        ICell this[int row, int col] { get; set; }
    }
}