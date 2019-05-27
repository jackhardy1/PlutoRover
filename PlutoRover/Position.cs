namespace PlutoRover
{
    public class Position
    {
        public int YCoordinate { get; set; }

        public int XCoordinate { get; set; }

        public string Direction { get; set; }

        public Position(int _yCoordinate, int _xCoordinate, string _direction)
        {
            this.YCoordinate = _yCoordinate;
            this.XCoordinate = _xCoordinate;
            this.Direction = _direction;
        }
    }
}
