namespace PlutoRover
{
    public static class PositionExtensions
    {
        public static Position Clone(this Position positionToClone)
        {
            return new Position(positionToClone.yCoordinate, positionToClone.xCoordinate, positionToClone.direction);
        }
    }
}
