using MathTricks.Enums;
using MathTricks.GameObjects;

namespace MathTricks.Core
{
    public class Engine
    {
        private Player firstPlayer;
        private Player secondPlayer;
        public Engine(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }
        public void Run()
        {
            int count = 0;
            while (true)
            {
                string command = Console.ReadLine();
                int[] direction = GetDirection(command);
            }
        }

        private int[] GetDirection(string command)
        {
            switch (command)
            {
                case "up":
                    return new int[] { -1, 0 };
                case "down":
                    return new int[] { 1, 0 };
                case "left":
                    return new int[] { 0, -1 };
                case "right":
                    return new int[] { 0, 1 };
                case "downleft":
                    return new int[] { 1, -1 };
                case "downright":
                    return new int[] { 1, 1 };
                case "upleft":
                    return new int[] { -1, -1 };
                case "upright":
                    return new int[] { -1, 1 };
            }
        }
    }
}
