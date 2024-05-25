namespace MathTricks.GameObjects
{
    public class Player(Board board) : Poll
    {
        private int playerPoints;
        public int GetPlayerPoints() => this.playerPoints;
        public int GetPlayerRows() => this.NextRowPos;
        public int GetPlayerCols() => this.NextColPos;
        public  bool CanPlayerMove(int row, int col)
        {
            if (IsPlayerSurroundedByUsedOperations())
            {
                return false;
            }
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

        private bool IsPlayerSurroundedByUsedOperations()
        {
            var uperCordinates =  new[] { NextRowPos - 1, NextColPos };
            var downCordinates = new[] { NextRowPos + 1, NextColPos };
            var leftCordinates = new[] { NextRowPos, NextColPos - 1 };
            var rightCordinates = new[] { NextRowPos, NextColPos + 1 };
            var upLeftCordinates = new[] { NextRowPos - 1, NextColPos - 1 };
            var upRightCordinates = new[] { NextRowPos - 1, NextColPos + 1 };
            var downLeftCordinates = new[] { NextRowPos + 1, NextColPos - 1 };
            var downRightCordinates = new[] { NextRowPos + 1, NextColPos + 1 };
            if  (board.IsOnBoard(uperCordinates[0], uperCordinates[1])  &&  
                 !board.PlayersUsedArithmeticOperations.Contains(board.GetBoardValue(uperCordinates[0], uperCordinates[1])))
            {
                return false;
            }

            if (board.IsOnBoard(downCordinates[0], downCordinates[1]) &&
                !board.PlayersUsedArithmeticOperations.Contains(board.GetBoardValue(downCordinates[0], downCordinates[1])))
            {
                return false;
            }
            if (board.IsOnBoard(leftCordinates[0], leftCordinates[1]) &&
                !board.PlayersUsedArithmeticOperations.Contains(board.GetBoardValue(leftCordinates[0], leftCordinates[1])))
            {
                return false;
            }
            if (board.IsOnBoard(rightCordinates[0], rightCordinates[1]) &&
                !board.PlayersUsedArithmeticOperations.Contains(board.GetBoardValue(rightCordinates[0], rightCordinates[1])))
            {
                return false;
            }
            if (board.IsOnBoard(upLeftCordinates[0], upLeftCordinates[1]) &&
               ! board.PlayersUsedArithmeticOperations.Contains(board.GetBoardValue(upLeftCordinates[0], upLeftCordinates[1])))
            {
                return false;
            }
            if (board.IsOnBoard(upRightCordinates[0], upRightCordinates[1]) &&
                !board.PlayersUsedArithmeticOperations.Contains(board.GetBoardValue(upRightCordinates[0], upRightCordinates[1])))
            {
                return false;
            } 
            if (board.IsOnBoard(downLeftCordinates[0], downLeftCordinates[1]) &&
               ! board.PlayersUsedArithmeticOperations.Contains(board.GetBoardValue(downLeftCordinates[0], downLeftCordinates[1])))
            {
                return false;
            }
            if (board.IsOnBoard(downRightCordinates[0], downRightCordinates[1]) &&
                !board.PlayersUsedArithmeticOperations.Contains(board.GetBoardValue(downRightCordinates[0], downRightCordinates[1])))
            {
                return false;
            }
            return true;
        }

       
    }
}
