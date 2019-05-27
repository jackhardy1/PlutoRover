using Microsoft.AspNetCore.Mvc;

namespace PlutoRover.API.Controllers
{
    [Route("api/rover")]
    [ApiController]
    public class RoverController : ControllerBase
    { 
        [HttpPost]
        public ActionResult<Report> Post([FromBody] CommandsRequest request)
        {
            var rover = new Rover(request.startingPosition, request.grid);

            Report report = rover.Move(request.commands);

            return report;
        }
    }
}
