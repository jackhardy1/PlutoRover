namespace PlutoRover
{
    public static class PositionExtensions
    {
        public static Position Clone(this Position positionToClone)
        {
            return new Position(positionToClone.YCoordinate, positionToClone.XCoordinate, positionToClone.Direction);
        }
    }
}
