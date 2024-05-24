using MathTricks.Core;
using MathTricks.GameObjects;

namespace MathTricks
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(4,6);
            Engine engine = new Engine(board);
        }
    }
}
