using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTricks.GameObjects
{
    public class FirstPlayer : Player
    {
        public FirstPlayer(Board board) 
            : base(board)
        {
            this.NextRowPos = 0;
            this.NextColPos = 0;
        }
    }
}
