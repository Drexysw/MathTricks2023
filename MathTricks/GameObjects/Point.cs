using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTricks.GameObjects
{
    public class Point
    {
        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }
        public int LeftX { get; set; }
        public int TopY { get; set; } 
    }
}
