namespace Labyrinth.Interfaces
{
    public interface IMaze: IRenderable
    {
        int Rows { get; }

        int Cols { get; }

        ICell this[int row, int col] { get; set; }

        void GenerateMaze();
    }
}