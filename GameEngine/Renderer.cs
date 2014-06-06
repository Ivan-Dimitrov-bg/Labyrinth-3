using Labyrinth.Interfaces;

namespace Labyrinth.GameEngine
{
    public class Renderer
    { 
        public void Render(IRenderable obj)
        {
            obj.Render();
        }
    }
}