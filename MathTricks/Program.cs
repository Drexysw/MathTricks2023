using MathTricks.Core;
using MathTricks.GameObjects;

namespace MathTricks
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(3, 6);
            Player firstPlayer = new Player(board);
            Player SecondPlayer = new Player(board);
            Engine engine = new Engine(firstPlayer, SecondPlayer);
            engine.Run();
        }
    }
}
