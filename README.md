# LineSegmentCrossingSquares
C# implementation of getting line segment intersecting squares algorithm

The algorithm determines all squares that intersect the line segment. 

There are some similar algorithms that can form close approximation to a straight line between two points. For exmaple Bresenham's line algorithm https://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm. But such algoritms ignore "slightly intersecting" squares (the sqaures that are intersected just in their corners). The purpose of this algorithm is to find all intersecting squares.

The idea is to iteratively increase x value from start line segment point x to end line segment point x on one square size. During every x iteration we find 2 intersecting points with vertical lines: x and x + square size. Then we iterate y within these 2 points to collect intersecting squares. See https://github.com/morozec/LineSegmentCrossingSquares/wiki page to get the idea.  
