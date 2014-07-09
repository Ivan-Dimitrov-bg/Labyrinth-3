namespace Labyrinth.Interfaces
{
    using System;

    public interface IRenderer
    {
        ConsoleColor Color { set; }

        void Render(string message, params object[] args);

        string ReadCommand();

        void Clear();
    }
}