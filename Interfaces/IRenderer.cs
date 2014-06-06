
namespace Labyrinth.Interfaces
{
    public interface IRenderer
    {
        void RenderMessage(string msg, params object[] obj);

        void RenderScore(IScoreBoard scoreboard, IPlayer player);

        void RenderMaze(IMaze maze);
    }
}
