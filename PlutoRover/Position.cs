using System;
namespace PlutoRover
{
    public class Position
    {
        public int yCoordinate { get; set; }

        public int xCoordinate { get; set; }

        public string direction { get; set; }

        public Position(int yCoordinate, int xCoordinate, string direction)
        {
            this.yCoordinate = yCoordinate;
            this.xCoordinate = xCoordinate;
            this.direction = direction;
        }
    }
}
