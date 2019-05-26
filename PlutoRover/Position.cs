namespace PlutoRover
{
    public class Position
    {
        public int yCoordinate { get; set; }

        public int xCoordinate { get; set; }

        public string direction { get; set; }

        public Position(int _yCoordinate, int _xCoordinate, string _direction)
        {
            this.yCoordinate = _yCoordinate;
            this.xCoordinate = _xCoordinate;
            this.direction = _direction;
        }
    }
}
