using System;
using System.Collections.Generic;

namespace LineSegmentIntersectingSquares
{
    public static class Calculator
    {
        private const double Tolerance = 1E-3;

        /// <summary>
        /// Main method to get all anchor crossing squares
        /// </summary>
        /// <param name="start">Start anchor point</param>
        /// <param name="end">End anchor point</param>
        /// <param name="squareSide">square side</param>
        /// <returns></returns>
        public static IList<Tuple<int, int>> GetLineSquares(Point start, Point end, int squareSide)
        {
            //invert anchor if start.X > end.X 
            var realStart = start.X <= end.X ? start : end;
            var realEnd = start.X <= end.X ? end : start;

            //get step coeffs depending on start and end points position
            var xCoeff = realEnd.X > realStart.X ? 1 : -1;
            var yCoeff = realEnd.Y > realStart.Y ? 1 : -1;

            //get left and top coords of containing start point square
            var startX = GetSquareIndex(realStart.X, squareSide) * squareSide;
            var startY = GetSquareIndex(realStart.Y, squareSide) * squareSide;

            //get left and top coords of containing end point square
            var endX = GetSquareIndex(realEnd.X, squareSide) * squareSide;
            var endY = GetSquareIndex(realEnd.Y, squareSide) * squareSide;

            //add containing start point square 
            var result = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(GetSquareIndex(startX, squareSide), GetSquareIndex(startY, squareSide))
            };
            var x = startX;
            var y = startY;

            while (x != endX) //while anchor is not finished
            {
                var newX = x + squareSide * xCoeff;//x coord of next x border
                var yReal = Math.Abs(end.X - start.X) < Tolerance ? start.Y : start.Y + (end.Y - start.Y) * (newX - start.X) / (end.X - start.X);//y coord of next x border 
                var newY = GetSquareIndex(yReal, squareSide) * squareSide;//top coord of containing yReal square 
                while (y != newY) //look through current anchor [(x, y), (newX, newY)] 
                {
                    y += squareSide * yCoeff;//y coord of next y border
                    result.Add(new Tuple<int, int>(GetSquareIndex(x, squareSide), GetSquareIndex(y, squareSide)));//add all squares while y != newY  
                }
                result.Add(new Tuple<int, int>(GetSquareIndex(newX, squareSide), GetSquareIndex(newY, squareSide)));//add final square for current anchor 
                x = newX;
            }

            {//final step to add squares with x: endX - squareSide < x <= endX 
                var newY = GetSquareIndex(endY, squareSide) * squareSide;
                while (y != newY)
                {
                    y += squareSide * yCoeff;
                    result.Add(new Tuple<int, int>(GetSquareIndex(x, squareSide), GetSquareIndex(y, squareSide)));
                }
            }

            return result;
        }

        /// <summary>
        /// Get containg value square index
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="squareSide">sqaure side</param>
        /// <returns></returns>
        private static int GetSquareIndex(double value, int squareSide)
        {
            return (int)Math.Floor(value / squareSide);
        }
    }
}
