namespace Labyrinth.Interfaces
{
    public interface ICell:IRenderable
    {
        char Value { get; set; }

        bool IsEmpty { get; }
    }
}