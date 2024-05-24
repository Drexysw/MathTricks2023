namespace MathTricks.GameObjects
{
    public class Board
    {
        private string[,] board;
        private Random random;
        public Board(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            random = new Random();
            IsParametersCorrect(rows, cols);
            InitializeBoard();
            PrintBoarder();
        }

        private static void IsParametersCorrect(int rows, int cols)
        {
            if (rows < 4 || cols < 4)
            {
                throw new ArgumentException("Rows and columns must be at least 4.");
            }
        }

        public int Rows { get; set; }

        public int Cols { get; set; }

        private List<char> ArithmeticOperations { get; set; } = ['-', '*', '/', '+'];

        private void InitializeBoard()
        {
            this.board = new string[Rows, Cols];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    string randomOperation = ArithmeticOperations[random.Next(0, 4)].ToString() == "+" ? string.Empty : ArithmeticOperations[random.Next(0, 4)].ToString();
                    string randomNumber = random.Next(0, 30).ToString();
                    if (i == 0 && j == 0 || i == Rows - 1 && j == Cols - 1)
                    {
                        this.board[i, j] = "0";
                        continue;
                    }
                    if (randomNumber == "0" && randomOperation != "/")
                    {
                        this.board[i, j] = $"{randomOperation}{randomNumber}";
                        continue;
                    }
                    this.board[i, j] = $"{randomOperation}{randomNumber}";
                }
            }
        }

        private void PrintBoarder()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}


