using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.Interfaces
{
    public interface IScore : IRenderable
    {
        int Moves { get; set; }

        int Position { get; set; }

        string Name { get; set; }
    }
}