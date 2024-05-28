using MathTricks.GameObjects;

namespace MathTricks.Core.ServiceModels
{
    public sealed class FirstPlayer : Player
    {
        public FirstPlayer(Board board)
            : base(board)
        {
            NextRowPos = 0;
            NextColPos = 0;
        }
    }
}
