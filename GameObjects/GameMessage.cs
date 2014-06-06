using System;
using Labyrinth.Interfaces;

namespace Labyrinth.GameObjects
{
    public class GameMessage : IRenderable
    {
        private readonly string Message;
        private readonly object[] Args;

        public GameMessage(string message, params object[] args)
        {
            this.Message = message;
            this.Args = args;
        }

        public void Render()
        {
            if (this.Args == null)
            {
                Console.WriteLine(this.Message);
            }
            else
            {
                Console.WriteLine(this.Message, this.Args);
            }
        }
    }
}