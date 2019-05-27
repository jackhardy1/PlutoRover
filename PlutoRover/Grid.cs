using System.Collections.Generic;

namespace PlutoRover
{
    public class Grid
    {
        public int YBoundary { get; set; }
        public int XBoundary { get; set; }
        public IList<Coordinates> Obstacles { get; set; }

        public Grid(int _yBoundary, int _xBoundary, IList<Coordinates> _obstacles = null)
        {
            this.YBoundary = _yBoundary;
            this.XBoundary = _xBoundary;
            this.Obstacles = _obstacles;
        }
    }
}
