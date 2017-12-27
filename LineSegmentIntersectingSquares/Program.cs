using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSegmentIntersectingSquares
{
    class Program
    {  

        static void Main(string[] args)
        {
            var res = Calculator.GetLineSquares(new Point() { X = 48, Y = 48 }, new Point() { X = 368, Y = 176 }, 32);
        }
    }
}
