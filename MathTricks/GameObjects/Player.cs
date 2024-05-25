using System.Linq;

namespace MathTricks.GameObjects
{
    public class Player : Poll
    {
        private Board board;
        public Player(Board board)
        {
            this.board = board;
            this.PlayerPoints = 0;
        }

        public int PlayerPoints { get; set; }

        public virtual bool CanPlayerMove(int row, int col)
        {
            if (this.board.HasPlayerHitTheBoard(row, col))
            {
                return false;
            }
            GetNextPosition(row, col);
            string boardValue = board.GetBoardValue(NextRowPos, NextColPos);
            if (this.board.PlayersUsedArithmeticOperations.Contains(boardValue))
            {
                return false;
            }
            this.board.PlayersUsedArithmeticOperations.Add(boardValue);
            IncreasePlayerPoints(boardValue);
            return true;
        }

        private void IncreasePlayerPoints(string arithmeticOperation)
        {
            if (arithmeticOperation == "0")
            {
                PlayerPoints = 0;
                return;
            }
            string operation = arithmeticOperation.First().ToString();
            if (!board.ArithmeticOperations.Contains(char.Parse(operation)))
            {
                PlayerPoints += int.Parse(arithmeticOperation);
                return;
            }
            string number = arithmeticOperation.Remove(0, 1);
            switch (operation)
            {
                case "-":
                    PlayerPoints -= int.Parse(number);
                    break;
                case "*":
                    PlayerPoints *= int.Parse(number);
                    break;
                case "/":
                    PlayerPoints /= int.Parse(number);
                    break;
            }
        }
        private void GetNextPosition(int row, int col)
        {
            this.NextRowPos = row;
            this.NextColPos = col;
        }

    }
}
