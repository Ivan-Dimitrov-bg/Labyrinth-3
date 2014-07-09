using System.Threading;

namespace Labyrinth.GameEngine
{
    public static class GameMain
    {
        public static void Main()
        {
            //Facade pattern
            LabyrinthGame game = new LabyrinthGame();
            game.Start();
        }
    }
}