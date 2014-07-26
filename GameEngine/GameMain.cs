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
            LabyrinthGame game = new LabyrinthGame();
            game.Start();
        }
    }
}