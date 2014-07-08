namespace Labyrinth.GameEngine
{
    using System;
    using Labyrinth.Interfaces;

    public class Renderer : IRenderer
    {
        private const string STRING_FORMAT = "{0,2}";

        public Renderer()
        {
            this.Color = ConsoleColor.White;
        }

        public ConsoleColor Color { private get; set; }
        
        public void Render(string message, params object[] args)
        {
            Console.ForegroundColor = this.Color;

            if (args.Length == 0)
            {
                Console.Write(STRING_FORMAT, message);
            }
            else
            {
                Console.Write(message, args);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}