namespace Labyrinth.Interfaces
{
    using Labyrinth.ScoreUtils;

    public interface IScoreBoard :IRenderable
    {
        int Count { get; }
        
        void AddScore(PlayerScore currentPlayer);
    }
}