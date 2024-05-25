using MathTricks.Core;
using MathTricks.Core.ServiceModels;
using MathTricks.GameObjects;

namespace MathTricks
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board(5, 6);
            var firstPlayer = new FirstPlayer(board);
            var SecondPlayer = new SecondPlayer(board);
            var engine = new Engine(firstPlayer, SecondPlayer);
            engine.Run();
        }
    }
}
