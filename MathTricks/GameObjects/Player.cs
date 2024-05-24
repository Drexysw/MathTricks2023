﻿namespace MathTricks.GameObjects
{
    public class Player
    {
        private Board board;
        public Player(Board board)
        {
            this.board = board;
            this.NextRowPos = 0;
            this.NextColPos = 0;
            this.PlayerPoints = 0;
        }

        public int PlayerPoints { get; set; }
        private int NextRowPos { get; set; }
        private int NextColPos { get; set; }

        public bool CanPlayerMove(int row, int col)
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
            if (arithmeticOperation.Length == 1)
            {
                PlayerPoints += int.Parse(arithmeticOperation);
                return;
            }
            string operation = arithmeticOperation.First().ToString();
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
