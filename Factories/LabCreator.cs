namespace Labyrinth.Factories
{
    using Labyrinth.Interfaces;
    using System;
    using System.Linq;

    public abstract class LabCreator
    {
        public abstract IMaze CreateLabyrinth();
    }
}
