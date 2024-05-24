using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathTricks.GameObjects;

namespace MathTricks.Core
{
    public class Engine
    {
        private Board board;
        public Engine(Board board)
        {
            this.board = board;
        }

        public void Run()
        {
            Console.WriteLine("Engine is running");
        }
    }
}
