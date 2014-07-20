namespace Labyrinth.Interfaces
{
    /// <summary>
    /// Inherits the IRenderable interface
    /// <remarks>
    /// Contains count and AddScore
    /// </remarks>
    /// </summary>
    public interface IScoreBoard : IRenderable
    {
        int Count { get; }

        void AddScore(IScore currentPlayer);
    }
}