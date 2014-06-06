using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.GameEngine;
using Labyrinth.Interfaces;

namespace Labyrinth.GameObjects
{
    public class GameMessage : Renderer, IRenderable
    {
        private string message;
        private object[] args;

        public GameMessage(string message, params object[] args)
        {
            this.message = message;
            this.args = args;
        }

        public void Render()
        {
            if (args == null)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine(message, args);
            }
        }
    }
}