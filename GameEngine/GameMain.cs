using Labyrinth.GameObjects;
using Labyrinth.Interfaces;

namespace Labyrinth.GameEngine
{
    /// <summary>
    /// GameMain class
    /// <remarks>
    /// Implements the Facade pattern. Will initialize the labyrint game and then start it
    /// </remarks>
    /// </summary>
    public static class GameMain
    {
        public static void Main()
        {
            // Facade pattern
            PlayerCommand command = PlayerCommand.Exit;
            LabyrinthGame game = new LabyrinthGame();
            game.Start();
        }
    }
}