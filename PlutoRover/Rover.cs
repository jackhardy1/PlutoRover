using System.Collections.Generic;
using static PlutoRover.Commands;
using static PlutoRover.Directions;

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
                        this.MoveForward();
                        break;

                    case Backward:
                        this.MoveBackward();
                        break;
                }
            }
            return this.position;
        }

        private void MoveForward()
        {
            switch (this.position.direction)
            {
                case North:
                    this.MoveNorth();
                    break;

                case East:
                    this.MoveEast();
                    break;

                case South:
                    this.MoveSouth();
                    break;

                case West:
                    this.MoveWest();
                    break;
            }
        }

        private void MoveBackward()
        {
            switch (this.position.direction)
            {
                case North:
                    this.MoveSouth();
                    break;

                case East:
                    this.MoveWest();
                    break;

                case South:
                    this.MoveNorth();
                    break;

                case West:
                    this.MoveEast();
                    break;
            }
        }

        private void MoveNorth()
        {
            if (this.position.yCoordinate + 1 > this.grid.yBoundary)
            {
                this.position.yCoordinate = 0;
            }
            else
            {
                this.position.yCoordinate += 1;
            }
        }   

        private void MoveEast()
        {
            if (this.position.xCoordinate + 1 > this.grid.xBoundary)
            {
                this.position.xCoordinate = 0;
            }
            else
            {
                this.position.xCoordinate += 1;
            }
        }

        private void MoveSouth()
        {
            if (this.position.yCoordinate - 1 < 0)
            {
                this.position.yCoordinate = this.grid.yBoundary;
            }
            else
            {
                this.position.yCoordinate -= 1;
            }
        }

        private void MoveWest()
        {
            if (this.position.xCoordinate - 1 < 0)
            {
                this.position.xCoordinate = this.grid.xBoundary;
            }
            else
            {
                this.position.xCoordinate -= 1;
            }
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
