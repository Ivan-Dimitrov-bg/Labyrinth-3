using System;
using Labyrinth.Interfaces;

namespace Labyrinth.GameEngine
{
    public class Renderer : IRenderer
    { 
        public void Render(string message, params object[] args)
        {
            if (args.Length == 0)
            {
                Console.Write("{0,2}",message);
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