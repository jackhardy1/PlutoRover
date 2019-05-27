using System.Collections.Generic;
using static PlutoRover.Commands;
using static PlutoRover.Directions;
using System.Linq;

namespace PlutoRover
{
    public class Rover
    {
        private Position Position { get; set; }
        private Grid Grid { get; set; }

        public Rover(Position _position, Grid _grid)
        {
            this.Position = _position;
            this.Grid = _grid;
        }

        public Report Move(IList<string> commands)
        {
            foreach (string command in commands)
            {
                switch (command)
                {
                    case Left:
                        this.TurnLeft();
                        break;

                    case Right:
                        this.TurnRight();
                        break;

                    case Forward:
                        Position positionForward = this.PositionForward();
                        if (this.ObstacleIsInPath(positionForward))
                        {
                            return this.ReportObstacle(positionForward);
                        }

                        this.SetNewPosition(positionForward);
                        break;

                    case Backward:
                        Position positionBackward = this.PositionBackward();
                        if (this.ObstacleIsInPath(positionBackward))
                        {
                            return this.ReportObstacle(positionBackward);
                        }

                        this.SetNewPosition(positionBackward);
                        break;
                }
            }
            return new Report {
                FinalPosition = this.Position,
                EncounteredObstacle = false,
                Message = "Successfully carried out all commands"
            };
        }

        private Report ReportObstacle(Position positionOfObstacle) 
        {
            return new Report
            {
                FinalPosition = this.Position,
                EncounteredObstacle = true,
                Message = $"An obstacle was encountered at position: X {positionOfObstacle.XCoordinate}, Y {positionOfObstacle.YCoordinate}"
            };
        }

        private void SetNewPosition(Position newPosition)
        {
            this.Position = newPosition;
        }

        private bool ObstacleIsInPath(Position positionAhead)
        {
            if (this.Grid.Obstacles == null)
            {
                return false;
            }

            var obstacleInPath = this.Grid.Obstacles.FirstOrDefault(x =>
                x.XValue == positionAhead.XCoordinate &&
                x.YValue == positionAhead.YCoordinate);

            if (obstacleInPath != null)
            {
                return true;
            }

            return false;
        }

        private Position PositionForward()
        {
            Position positionAhead = null;
            switch (this.Position.Direction)
            {
                case North:
                    positionAhead = this.PositionNorth();
                    break;

                case East:
                    positionAhead = this.PositionEast();
                    break;

                case South:
                    positionAhead = this.PositionSouth();
                    break;

                case West:
                    positionAhead = this.PositionWest();
                    break;
            }
            return positionAhead;
        }

        private Position PositionBackward()
        {
            Position positionAhead = null;
            switch (this.Position.Direction)
            {
                case North:
                    positionAhead = this.PositionSouth();
                    break;

                case East:
                    positionAhead = this.PositionWest();
                    break;

                case South:
                    positionAhead = this.PositionNorth();
                    break;

                case West:
                    positionAhead = this.PositionEast();
                    break;
            }
            return positionAhead;
        }

        private Position PositionNorth()
        {
            var newPosition = this.Position.Clone();

            if (this.Position.YCoordinate + 1 > this.Grid.YBoundary)
            {
                newPosition.YCoordinate = 0;
            }
            else
            {
                newPosition.YCoordinate = this.Position.YCoordinate + 1;
            }

            return newPosition;
        }

        private Position PositionEast()
        {
            var newPosition = this.Position.Clone();

            if (this.Position.XCoordinate + 1 > this.Grid.XBoundary)
            {
                newPosition.XCoordinate = 0;
            }
            else
            {
                newPosition.XCoordinate = this.Position.XCoordinate + 1;
            }

            return newPosition;
        }

        private Position PositionSouth()
        {
            var newPosition = this.Position;

            if (this.Position.YCoordinate - 1 < 0)
            {
                newPosition.YCoordinate = this.Grid.YBoundary;
            }
            else
            {
                newPosition.YCoordinate = this.Position.YCoordinate - 1;
            }

            return newPosition;
        }

        private Position PositionWest()
        {
            var newPosition = this.Position;

            if (this.Position.XCoordinate - 1 < 0)
            {
                newPosition.XCoordinate = this.Grid.XBoundary;
            }
            else
            {
                newPosition.XCoordinate = this.Position.XCoordinate - 1;
            }

            return newPosition;
        }

        private void TurnLeft()
        {
            switch (this.Position.Direction)
            {
                case North:
                    this.Position.Direction = West;
                    break;
                case East:
                    this.Position.Direction = North;
                    break;
                case South:
                    this.Position.Direction = East;
                    break;
                case West:
                    this.Position.Direction = South;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.Position.Direction)
            {
                case North:
                    this.Position.Direction = East;
                    break;
                case East:
                    this.Position.Direction = South;
                    break;
                case South:
                    this.Position.Direction = West;
                    break;
                case West:
                    this.Position.Direction = North;
                    break;
            }
        }
    }
}
