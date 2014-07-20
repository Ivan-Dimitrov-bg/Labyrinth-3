namespace Labyrinth.Interfaces
{
    using System;

    /// <summary>
    /// Base interface for the console output and renderer
    /// <remarks>
    /// Is inherited by the game output renderer
    /// </remarks>
    /// </summary>
    public interface IRenderer
    {
        ConsoleColor Color { set; }

        void Render(string message, params object[] args);

        string ReadCommand();

        void Clear();
    }
}