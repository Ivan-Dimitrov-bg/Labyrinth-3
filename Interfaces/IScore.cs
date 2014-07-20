namespace Labyrinth.Interfaces
{
    /// <summary>
    /// Inherits the IRenderable interface
    /// <remarks>
    /// Contains Moves, Position and Name each with it own getter and setter
    /// </remarks>
    /// </summary>
    public interface IScore : IRenderable
    {
        int Moves { get; set; }

        int Position { get; set; }

        string Name { get; set; }
    }
}