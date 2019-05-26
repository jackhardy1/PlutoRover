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

        [Fact]
        public void Rover_Can_Move_Backward()
        {
            var startingPosition = new Position(1, 0, North);
            var rover = new Rover(startingPosition);

            var position = rover.Move(new List<string> { Backward });

            Assert.Equal(0, position.yCoordinate);
            Assert.Equal(0, position.xCoordinate);
            Assert.Equal(North, position.direction);
        }

        [Fact]
        public void Rover_Can_Move_Forward_And_Backward()
        {
            var startingPosition = new Position(0, 0, North);
            var rover = new Rover(startingPosition);

            var position = rover.Move(new List<string> { Forward, Forward, Forward, Forward, Backward, Backward });

            Assert.Equal(2, position.yCoordinate);
            Assert.Equal(0, position.xCoordinate);
            Assert.Equal(North, position.direction);
        }

        [Fact]
        public void Rover_Can_Turn_Left()
        {
            var startingPosition = new Position(0, 0, North);
            var rover = new Rover(startingPosition);

            var position = rover.Move(new List<string> { Left });

            Assert.Equal(0, position.xCoordinate);
            Assert.Equal(0, position.yCoordinate);
            Assert.Equal(West, position.direction);
        }

        [Fact]
        public void Rover_Can_Turn_Left_Multiple_Times()
        {
            var startingPosition = new Position(0, 0, North);
            var rover = new Rover(startingPosition);

            var position = rover.Move(new List<string> { Left, Left, Left });

            Assert.Equal(0, position.xCoordinate);
            Assert.Equal(0, position.yCoordinate);
            Assert.Equal(East, position.direction);
        }
    }
}
