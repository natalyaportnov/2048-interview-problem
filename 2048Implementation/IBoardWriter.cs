
namespace _2048Implementation
{
    public interface IBoardWriter
    {
        void Clear();
        void WriteBoard(IBoard board);
        void WriteMessage(string message);
    }
}
