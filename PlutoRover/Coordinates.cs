namespace PlutoRover
{
    public class Coordinates
    {
        public int YValue { get; set; }
        public int XValue { get; set; }

        public Coordinates(int _yValue, int _xValue)
        {
            this.YValue = _yValue;
            this.XValue = _xValue;
        }
    }
}
