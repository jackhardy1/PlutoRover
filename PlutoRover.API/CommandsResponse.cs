using System;
namespace PlutoRover.API
{
    public class CommandsResponse
    {
        public Position FinalPosition { get; set; }

        public bool FoundObstacleInPath { get; set; }

        public string ObstacleCollisionMessage { get; set; }
    }
}
