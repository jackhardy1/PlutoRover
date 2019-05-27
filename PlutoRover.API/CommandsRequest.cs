using System.Collections.Generic;
namespace PlutoRover.API
{
    public class CommandsRequest
    {
        public Position startingPosition { get; set; }
        public Grid grid { get; set; }
        public IList<string> commands { get; set; }
    }
}
