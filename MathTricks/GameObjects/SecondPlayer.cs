namespace MathTricks.GameObjects
{
    public class SecondPlayer : Player
    {
        public SecondPlayer(Board board) 
            : base(board)
        {
            this.NextRowPos = board.GetLastPosition().First();
            this.NextColPos = board.GetLastPosition().Last();
        }
    }
}
