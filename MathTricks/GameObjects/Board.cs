﻿namespace MathTricks.GameObjects
{
    public  class Board
    {
        private int rows;
        private int cols;
        private string[,] board;
        private Random random;
        public Board()
        {
            random = new Random();
            this.Rows = random.Next(4,10);
            this.Cols = random.Next(4,10);
            PlayersUsedArithmeticOperations = new List<string>();
            InitializeBoard();
            PrintBoarder();
        }
        private int Rows
        {
            get => rows;
            set
            {
                if (value < 4)
                {
                    throw new ArgumentException("Rows must be at least 4.");
                }
                rows = value;
            }
        }

        private int Cols
        {
            get => cols;
            set
            {
                if (value < 4)
                {
                    throw new ArgumentException("Columns must be at least 4.");
                }
                cols = value;
            }
        }

        private List<char> ArithmeticOperations => ['-', '*', '/', '+'];
        private List<string> PlayersUsedArithmeticOperations { get; set; }
        public void AddUsedArithmeticOperation(string operation) => PlayersUsedArithmeticOperations.Add(operation);
        public List<char> GetArithmeticOperations() => ArithmeticOperations;
        public List<string> GetUsedArithmeticOperations() => PlayersUsedArithmeticOperations;
        private void InitializeBoard()
        {
            this.board = new string[Rows, Cols];
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    SetMatrixValue(row, col);
                }
            }
        }

        private void SetMatrixValue(int row, int col)
        {
            var operation = ArithmeticOperations[random.Next(0, 4)].ToString();
            string symbolOfOperation = operation == "+" ? string.Empty : operation;
            string randomNumber = random.Next(0, 30).ToString();
            if (row == 0 && col == 0 || row == Rows - 1 && col == Cols - 1)
            {
                this.board[row, col] = "0";
                return;
            }
            if (randomNumber == "0" && symbolOfOperation == "/")
            {
                this.board[row, col] = $"{randomNumber}";
                return;
            }
            this.board[row, col] = $"{symbolOfOperation}{randomNumber}";
        }

        private void PrintBoarder()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        public bool HasPlayerHitTheBoard(int row, int col) => row < 0 || row >= Rows || col < 0 || col >= Cols;
        public string GetBoardValue(int row, int col) => board[row, col];
        public int[] GetLastPosition() => [Rows - 1, Cols - 1];
        public bool IsOnBoard(int row, int col) => row >= 0 && row < Rows && col >= 0 && col < Cols;
    }
}


