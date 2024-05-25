using MathTricks.Core.ServiceModels;

namespace MathTricks.Core
{
    public class Engine(FirstPlayer firstPlayer, SecondPlayer secondPlayer)
    {
        public void Run()
        {
            int countOfTurns = 0;
            string command = string.Empty;
            var cordinates = new int[2];
            while (true)
            {
                bool IsFirstPlayer = countOfTurns % 2 == 0;
                Console.WriteLine(IsFirstPlayer ? "Its player1 turn" : "Its player2 turn");
                command = Console.ReadLine();
                bool isMoving;
                if (IsFirstPlayer)
                {
                    cordinates = GetNextPosition(firstPlayer.GetPlayerRows(), firstPlayer.GetPlayerCols(), GetDirection(command));
                    isMoving = firstPlayer.CanPlayerMove(cordinates[0], cordinates[1]);
                }
                else
                {
                    cordinates = GetNextPosition(secondPlayer.GetPlayerRows(), secondPlayer.GetPlayerCols(), GetDirection(command));
                    isMoving = secondPlayer.CanPlayerMove(cordinates[0], cordinates[1]);
                }
                countOfTurns++;
                if (!isMoving)
                {
                    Console.WriteLine(GetWinner());
                    break;
                }

            }
        }

        private int[] GetDirection(string command)
        {
            switch (command)
            {
                case "up":
                    return [-1, 0];
                case "down":
                    return [1, 0];
                case "left":
                    return [0, -1];
                case "right":
                    return [0, 1];
                case "downleft":
                    return [1, -1];
                case "downright":
                    return [1, 1];
                case "upleft":
                    return [-1, -1];
                case "upright":
                    return [-1, 1];
            }
            return new int[2];
        }
        private int[] GetNextPosition(int row, int col, int[] direction)
        {
            return [row + direction[0], col + direction[1]];
        }

        private string GetWinner()
        {
            int firstPlayerPoints = firstPlayer.GetPlayerPoints();
            int secondPlayerPoints = secondPlayer.GetPlayerPoints();
            if (firstPlayerPoints > secondPlayerPoints)
            {
                return $"Player 1 won the game: {firstPlayerPoints} (player 1) vs {secondPlayerPoints} (player 2)";
            }
            else if (firstPlayerPoints < secondPlayerPoints)
            {
                return $"Player 2 won the game: {firstPlayerPoints} (player 1) vs {secondPlayerPoints} (player 2)";
            }
            else
            {
                return $"Draw: {firstPlayerPoints} (player 1) vs {secondPlayerPoints} (player 2)";
            }
        }
    }
}

