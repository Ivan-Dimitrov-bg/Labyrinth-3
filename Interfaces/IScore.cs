namespace Labyrinth.Interfaces
{
    using System;
    using System.Linq;

    public interface IScore : IRenderable
    {
        int Moves { get; set; }

        int Position { get; set; }

        string Name { get; set; }
    }
}