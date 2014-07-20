namespace Labyrinth.Interfaces
{
    /// <summary>
    /// Inherits the IRenderable inrerface
    /// <remarks>
    /// None
    /// </remarks>
    /// </summary>
    public interface ICell : IRenderable
    {
        char Value { get; set; }

        bool IsEmpty { get; }
    }
}