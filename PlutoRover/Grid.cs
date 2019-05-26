using System;
using System.Collections.Generic;

namespace PlutoRover
{
    public class Grid
    {
        public int yBoundary { get; set; }
        public int xBoundary { get; set; }

        public Grid(int _yBoundary, int _xBoundary)
        {
            this.yBoundary = _yBoundary;
            this.xBoundary = _xBoundary;
        }
    }
}
