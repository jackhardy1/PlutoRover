using System.Collections.Generic;
using static PlutoRover.Commands;

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
                    case Forward:
                        this.position.yCoordinate += 1;
                        break;
                }
            }
            return this.position;
        }
    }
}
