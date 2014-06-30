using System;
using Labyrinth.Interfaces;

namespace Labyrinth.GameEngine
{
    public class Renderer: IRenderer
    { 

        public void Render(string message, params object[] args)
        {
            if (args == null)
            {
                Console.Write("{0}", message);
            }
            else
            {
                Console.Write(message, args);
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}