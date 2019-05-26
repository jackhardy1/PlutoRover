using System.Collections.Generic;
using static PlutoRover.Commands;
using static PlutoRover.Directions;

namespace PlutoRover
{
    public class Rover
    {
        private Position position { get; set; }

        public Rover(Position _position)
        {
            this.position = _position;
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
                    this.position.yCoordinate += 1;
                    break;

                case East:
                    this.position.xCoordinate += 1;
                    break;

                case South:
                    this.position.yCoordinate -= 1;
                    break;

                case West:
                    this.position.xCoordinate -= 1;
                    break;
            }
        }

        private void MoveBackward()
        {
            switch (this.position.direction)
            {
                case North:
                    this.position.yCoordinate -= 1;
                    break;

                case East:
                    this.position.xCoordinate -= 1;
                    break;

                case South:
                    this.position.yCoordinate += 1;
                    break;

                case West:
                    this.position.xCoordinate += 1;
                    break;
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
