using System;
using Xunit;
using System.Collections.Generic;
using PlutoRover;
using static PlutoRover.Commands;
using static PlutoRover.Directions;

namespace PlutoRover.Tests
{
    public class RoverTests
    {
        [Fact]
        public void Rover_Can_Move_Forward()
        {
            var startingPosition = new Position(0, 0, North);
            var rover = new Rover(startingPosition);

            var position = rover.Move(new List<string> { Forward });

            Assert.Equal(0, position.xCoordinate);
            Assert.Equal(1, position.yCoordinate);
            Assert.Equal(North, position.direction);
        }
    }
}
