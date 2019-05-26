using System.Collections.Generic;
using static PlutoRover.Commands;
using static PlutoRover.Directions;
using System.Linq;

namespace PlutoRover
{
    public class Rover
    {
        private Position position { get; set; }
        private Grid grid { get; set; }

        public Rover(Position _position, Grid _grid)
        {
            this.position = _position;
            this.grid = _grid;
        }

        public Position Move(IList<string> commands)
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
                            return this.position;
                        }

                        this.SetNewPosition(positionForward);
                        break;

                    case Backward:
                        Position positionBackward = this.PositionBackward();
                        if (this.ObstacleIsInPath(positionBackward))
                        {
                            return this.position;
                        }

                        this.SetNewPosition(positionBackward);
                        break;
                }
            }
            return this.position;
        }

        private void SetNewPosition(Position newPosition)
        {
            this.position = newPosition;
        }

        private bool ObstacleIsInPath(Position positionAhead)
        {
            if (grid.obstacles == null)
            {
                return false;
            }

            var obstacleInPath = this.grid.obstacles.FirstOrDefault(x =>
                x.xValue == positionAhead.xCoordinate &&
                x.yValue == positionAhead.yCoordinate);

            if (obstacleInPath != null)
            {
                return true;
            }

            return false;
        }

        private Position PositionForward()
        {
            Position positionAhead = null;
            switch (this.position.direction)
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
            switch (this.position.direction)
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
            var newPosition = this.position.Clone();

            if (this.position.yCoordinate + 1 > this.grid.yBoundary)
            {
                newPosition.yCoordinate = 0;
            }
            else
            {
                newPosition.yCoordinate = this.position.yCoordinate + 1;
            }

            return newPosition;
        }

        private Position PositionEast()
        {
            var newPosition = this.position.Clone();

            if (this.position.xCoordinate + 1 > this.grid.xBoundary)
            {
                newPosition.xCoordinate = 0;
            }
            else
            {
                newPosition.xCoordinate = this.position.xCoordinate + 1;
            }

            return newPosition;
        }

        private Position PositionSouth()
        {
            var newPosition = this.position;

            if (this.position.yCoordinate - 1 < 0)
            {
                newPosition.yCoordinate = this.grid.yBoundary;
            }
            else
            {
                newPosition.yCoordinate = this.position.yCoordinate - 1;
            }

            return newPosition;
        }

        private Position PositionWest()
        {
            var newPosition = this.position;

            if (this.position.xCoordinate - 1 < 0)
            {
                newPosition.xCoordinate = this.grid.xBoundary;
            }
            else
            {
                newPosition.xCoordinate = this.position.xCoordinate - 1;
            }

            return newPosition;
        }

        private void TurnLeft()
        {
            switch (this.position.direction)
            {
                case North:
                    this.position.direction = West;
                    break;
                case East:
                    this.position.direction = North;
                    break;
                case South:
                    this.position.direction = East;
                    break;
                case West:
                    this.position.direction = South;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.position.direction)
            {
                case North:
                    this.position.direction = East;
                    break;
                case East:
                    this.position.direction = South;
                    break;
                case South:
                    this.position.direction = West;
                    break;
                case West:
                    this.position.direction = North;
                    break;
            }
        }
    }
}
