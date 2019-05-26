using Xunit;
using System.Collections.Generic;
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
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Forward });

            Assert.Equal(1, report.FinalPosition.yCoordinate);
            Assert.Equal(0, report.FinalPosition.xCoordinate);
            Assert.Equal(North, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Can_Move_Backward()
        {
            var startingPosition = new Position(1, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Backward });

            Assert.Equal(0, report.FinalPosition.yCoordinate);
            Assert.Equal(0, report.FinalPosition.xCoordinate);
            Assert.Equal(North, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Can_Move_Forward_And_Backward()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Forward, Forward, Forward, Forward, Backward, Backward });

            Assert.Equal(2, report.FinalPosition.yCoordinate);
            Assert.Equal(0, report.FinalPosition.xCoordinate);
            Assert.Equal(North, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Can_Turn_Left()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Left });

            Assert.Equal(0, report.FinalPosition.yCoordinate);
            Assert.Equal(0, report.FinalPosition.xCoordinate);
            Assert.Equal(West, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Can_Turn_Left_Multiple_Times()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Left, Left, Left });

            Assert.Equal(0, report.FinalPosition.yCoordinate);
            Assert.Equal(0, report.FinalPosition.xCoordinate);
            Assert.Equal(East, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Can_Turn_Right()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Right });

            Assert.Equal(0, report.FinalPosition.yCoordinate);
            Assert.Equal(0, report.FinalPosition.xCoordinate);
            Assert.Equal(East, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Can_Turn_Right_Multiple_Times()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Right, Right, Right });

            Assert.Equal(0, report.FinalPosition.yCoordinate);
            Assert.Equal(0, report.FinalPosition.xCoordinate);
            Assert.Equal(West, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Can_Turn_And_Move_In_Different_Direction()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Forward, Forward, Forward, Right, Forward, Forward, Right, Backward, Backward });

            Assert.Equal(5, report.FinalPosition.yCoordinate);
            Assert.Equal(2, report.FinalPosition.xCoordinate);
            Assert.Equal(South, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Can_Go_Over_Grid_Boundary()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(100, 100);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Backward });

            Assert.Equal(0, report.FinalPosition.xCoordinate);
            Assert.Equal(100, report.FinalPosition.yCoordinate);
            Assert.Equal(North, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Can_Go_Over_Grid_Boundary_Both_Directions()
        {
            var startingPosition = new Position(0, 0, North);
            var grid = new Grid(250, 250);
            var rover = new Rover(startingPosition, grid);

            var report = rover.Move(new List<string> { Backward, Left, Forward });

            Assert.Equal(250, report.FinalPosition.xCoordinate);
            Assert.Equal(250, report.FinalPosition.yCoordinate);
            Assert.Equal(West, report.FinalPosition.direction);
        }

        [Fact]
        public void Rover_Stops_When_An_Obstacle_Is_Found()
        {
            var startingPosition = new Position(0, 0, North);
            var obstacles = new List<Coordinates>
            {
                new Coordinates(2,2)
            };

            var grid = new Grid(250, 250, obstacles);

            var rover = new Rover(startingPosition, grid);

            var report = rover.Move(new List<string> { Right, Forward, Forward, Left, Forward, Forward, Forward });

            Assert.Equal(1, report.FinalPosition.yCoordinate);
            Assert.Equal(2, report.FinalPosition.xCoordinate);
            Assert.Equal(North, report.FinalPosition.direction);
        }
    }
}
