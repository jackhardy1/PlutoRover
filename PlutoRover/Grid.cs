using System.Collections.Generic;

namespace PlutoRover
{
    public class Grid
    {
        public int yBoundary { get; set; }
        public int xBoundary { get; set; }
        public IList<Coordinates> obstacles { get; set; }

        public Grid(int _yBoundary, int _xBoundary, IList<Coordinates> _obstacles = null)
        {
            this.yBoundary = _yBoundary;
            this.xBoundary = _xBoundary;
            this.obstacles = _obstacles;
        }
    }
}
