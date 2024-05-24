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

        private List<char> ArithmeticOperations { get; set; } = ['-', '*', '/'];

        private void InitializeBoard()
        {
            this.board = new string[Rows, Cols];
            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (Rows == 0 && Cols == 0 || Rows == Rows - 1 && Cols == Cols - 1)
                    {
                        this.board[i, j] = "0";
                        continue;
                    }

                    if (count % 3 == 0)
                    {
                        this.board[i, j] = $"{ArithmeticOperations[random.Next(0, 3)]}{random.Next(1, 30)}";
                        count++;
                    }
                    else
                    {
                        this.board[i, j] = random.Next(1, 30).ToString();
                        count++;
                    }
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


