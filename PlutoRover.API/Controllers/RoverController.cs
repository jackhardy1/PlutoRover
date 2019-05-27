using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static PlutoRover.Commands;
using static PlutoRover.Directions;
using System;

namespace PlutoRover.API.Controllers
{
    [Route("api/rover")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        private readonly IList<string> validCommands = new List<string> { Forward, Backward, Left, Right };
        private readonly IList<string> validDirections = new List<string> { North, East, South, West };

        [HttpPost]
        public ActionResult<Report> Post([FromBody] CommandsRequest request)
        {
            var rover = new Rover(request.startingPosition, request.grid);

            this.CheckForValidCommands(request.commands);
            this.CheckForValidDirection(request.startingPosition.Direction);

            Report report = rover.Move(request.commands);

            return report;
        }

        private void CheckForValidCommands(IList<string> commands)
        {
            foreach(string command in commands)
            {
                if(!this.validCommands.Contains(command))
                {
                    throw new Exception($"{command} is not a valid command");
                }
            }
        }

        private void CheckForValidDirection(string direction) {
            if (!this.validDirections.Contains(direction)) 
            {
                throw new Exception($"{direction} is not a valid direction");
            }
        }
    }
}
