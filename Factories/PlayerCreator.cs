using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.GameObjects;
using Labyrinth.Interfaces;

namespace Labyrinth.Factories
{
    public static class PlayerCreator
    {
        public static IPlayer CreatePlayer(Position pos)
        {
            return new Player(pos);
        }
    }
}
