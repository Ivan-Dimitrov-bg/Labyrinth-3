namespace Labyrinth.Factories
{
    using Labyrinth.GameObjects;
    using Labyrinth.Interfaces;
    
    public static class PlayerCreator
    {
        private static IPlayer instance;
       
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