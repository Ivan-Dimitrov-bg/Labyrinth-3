namespace Labyrinth.Interfaces
{
    public interface ICell
    {
        char Value { get; set; }

        bool IsEmpty { get; }
    }
}