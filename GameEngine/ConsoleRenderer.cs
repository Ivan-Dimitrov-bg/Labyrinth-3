namespace Labyrinth.GameEngine
{
    using System;
    using Labyrinth.Interfaces;

    /// <summary>
    /// ConsoleRenderer class
    /// <remarks>
    /// Inherits the IRenderer interfaces
    /// </remarks>
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        private const string STRING_FORMAT = "{0,2}";

        /// <summary>
        /// Maze consturctor
        /// <remarks>
        /// Will set the console color upon initialization
        /// </remarks>
        /// </summary>
        public ConsoleRenderer()
        {
            this.Color = ConsoleColor.White;
        }

        /// <summary>
        /// Getter and setter for the Color value
        /// <remarks>
        /// None
        /// </remarks>
        /// </summary>
        public ConsoleColor Color { private get; set; }

        /// <summary>
        /// ReadCommand method
        /// <remarks>
        /// Will read a single line from the console
        /// </remarks>
        /// <returns>
        /// Will return a string which is read from the console
        /// </returns>
        /// </summary>
        public string ReadCommand()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Render method
        /// <remarks>
        /// Will validate provided arguments and set the color of the output message accordingly
        /// </remarks>
        /// </summary>
        /// <param name="message">
        /// Message to be printed on the console
        /// </param>
        /// <param name="args">
        /// Must not be null or will throw an exception
        /// </param>
        public void Render(string message, params object[] args)
        {
            Console.ForegroundColor = this.Color;

            if (args == null)
            {
                throw new NullReferenceException("Supplied args can't be null object!");
            }
            else if (args.Length == 0)
            {
                Console.Write(STRING_FORMAT, message);
            }
            else
            {
                Console.Write(message, args);
            }

            this.Color = ConsoleColor.White;
        }

        /// <summary>
        /// Will clear the console upon calling
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }
    }
}