using MathTricks.Core;
using MathTricks.GameObjects;

namespace MathTricks
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(5, 6);
            FirstPlayer firstPlayer = new FirstPlayer(board);
            SecondPlayer SecondPlayer = new SecondPlayer(board);
            Engine engine = new Engine(firstPlayer, SecondPlayer);
            engine.Run();
        }
    }
}
