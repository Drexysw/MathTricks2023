using MathTricks.GameObjects;

namespace MathTricks.Core.ServiceModels
{
    public sealed class SecondPlayer : Player
    {
        public SecondPlayer(Board board)
            : base(board)
        {
            NextRowPos = board.GetLastPosition().First();
            NextColPos = board.GetLastPosition().Last();
        }
    }
}
