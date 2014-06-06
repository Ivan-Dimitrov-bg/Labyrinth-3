namespace Labyrinth.Interfaces
{
    public interface IMaze
    {
        int Rows { get; }

        int Cols { get; }

        ICell this[int row, int col] { get; set; }

        void GenerateMaze();


    }
}