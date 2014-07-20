namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;

    /// <summary>
    /// PlayerCreator class
    /// </summary>
    public static class PlayerCreator
    {
        private static IPlayer instance;

        /// <summary>
        /// CreatePlayer method
        /// <remarks>
        /// If no instance exists will create a new instance of the player
        /// </remarks>
        /// </summary>
        public static IPlayer CreatePlayer()
        {
            if (instance == null)
            {
                instance = new Player();
            }

            return instance;
        }
    }
}