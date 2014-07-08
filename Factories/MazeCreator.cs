namespace Labyrinth.Factories
{
    using Labyrinth.Interfaces;
    using System;
    using System.Linq;

    public abstract class MazeCreator
    {
        public abstract IMaze CreateMaze();
    }
}
