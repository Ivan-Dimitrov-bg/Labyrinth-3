namespace Labyrinth.GameEngine
{
    using System;
    using Labyrinth.Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        private const string STRING_FORMAT = "{0,2}";

        public ConsoleRenderer()
        {
            this.Color = ConsoleColor.White;
        }

        public ConsoleColor Color { private get; set; }

        public string ReadCommand()
        {
            return Console.ReadLine();
        }

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

            this.Color = ConsoleColor.White;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}