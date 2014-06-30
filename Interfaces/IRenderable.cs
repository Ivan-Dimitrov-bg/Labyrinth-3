namespace Labyrinth.Interfaces
{
    public interface IRenderable
    {
        //Bridge pattern. All renderable objects recieve particular implementation of the renderer.
        void Render(IRenderer renderer);
    }
}
