using MathTricks.GameObjects;

namespace MathTricks.Core.ServiceModels
{
    public class SecondPlayer : Player
    {
        public SecondPlayer(Board board)
            : base(board)
        {
            NextRowPos = board.GetLastPosition().First();
            NextColPos = board.GetLastPosition().Last();
        }
    }
}
