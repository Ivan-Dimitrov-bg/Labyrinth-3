namespace Labyrinth.Interfaces
{
    public interface IRenderer
    {
        void Render(string message, params object[] args);

        void Clear();
    }
}
