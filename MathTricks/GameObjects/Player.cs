namespace MathTricks.GameObjects
{
    public class Player(Board board) : Poll
    {
        private int playerPoints;
        public  bool CanPlayerMove(int row, int col)
        {
            if (board.HasPlayerHitTheBoard(row, col))
            {
                return false;
            }
            GetNextPosition(row, col);
            string boardValue = board.GetBoardValue(NextRowPos, NextColPos);
            if (board.PlayersUsedArithmeticOperations.Contains(boardValue))
            {
                return false;
            }
            board.PlayersUsedArithmeticOperations.Add(boardValue);
            IncreasePlayerPoints(boardValue);
            return true;
        }

        private void IncreasePlayerPoints(string arithmeticOperation)
        {
            if (arithmeticOperation == "0")
            {
                playerPoints = 0;
                return;
            }
            string operation = arithmeticOperation.First().ToString();
            if (!board.ArithmeticOperations.Contains(char.Parse(operation)))
            {
                playerPoints += int.Parse(arithmeticOperation);
                return;
            }
            string number = arithmeticOperation.Remove(0, 1);
            switch (operation)
            {
                case "-":
                    playerPoints -= int.Parse(number);
                    break;
                case "*":
                    playerPoints *= int.Parse(number);
                    break;
                case "/":
                    playerPoints /= int.Parse(number);
                    break;
            }
        }
        private void GetNextPosition(int row, int col)
        {
            this.NextRowPos = row;
            this.NextColPos = col;
        }

        public int GetPlayerPoints() => this.playerPoints;
        public int GetPlayerRows() => this.NextRowPos;
        public int GetPlayerCols() => this.NextColPos;
    }
}
