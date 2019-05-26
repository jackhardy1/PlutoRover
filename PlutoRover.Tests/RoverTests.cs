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

            Assert.Equal(1, position.yCoordinate);
            Assert.Equal(0, position.xCoordinate);
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

            Assert.Equal(0, position.yCoordinate);
            Assert.Equal(0, position.xCoordinate);
            Assert.Equal(West, position.direction);
        }

        [Fact]
        public void Rover_Can_Turn_Left_Multiple_Times()
        {
            var startingPosition = new Position(0, 0, North);
            var rover = new Rover(startingPosition);

            var position = rover.Move(new List<string> { Left, Left, Left });

            Assert.Equal(0, position.yCoordinate);
            Assert.Equal(0, position.xCoordinate);
            Assert.Equal(East, position.direction);
        }

        [Fact]
        public void Rover_Can_Turn_Right()
        {
            var startingPosition = new Position(0, 0, North);
            var rover = new Rover(startingPosition);

            var position = rover.Move(new List<string> { Right });

            Assert.Equal(0, position.yCoordinate);
            Assert.Equal(0, position.xCoordinate);
            Assert.Equal(East, position.direction);
        }

        [Fact]
        public void Rover_Can_Turn_Right_Multiple_Times()
        {
            var startingPosition = new Position(0, 0, North);
            var rover = new Rover(startingPosition);

            var position = rover.Move(new List<string> { Right, Right, Right });

            Assert.Equal(0, position.yCoordinate);
            Assert.Equal(0, position.xCoordinate);
            Assert.Equal(West, position.direction);
        }

        [Fact]
        public void Rover_Can_Turn_And_Move_In_Different_Direction()
        {
            var startingPosition = new Position(0, 0, North);
            var rover = new Rover(startingPosition);

            var position = rover.Move(new List<string> { Forward, Forward, Forward, Right, Forward, Forward, Right, Backward, Backward });

            Assert.Equal(5, position.yCoordinate);
            Assert.Equal(2, position.xCoordinate);
            Assert.Equal(South, position.direction);
        }
    }
}
