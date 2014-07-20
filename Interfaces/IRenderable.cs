namespace Labyrinth.Interfaces
{
    public interface IRenderable
    {
        /// <summary>
        /// Bridge pattern
        /// <remarks>
        /// All renderable objects recieve particular implementation of the renderer.
        /// </remarks>
        /// </summary>
        void Render(IRenderer renderer);
    }
}
