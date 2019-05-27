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

            Report report = rover.Move(new List<string> { Forward });

            Position expectedPosition = new Position(1, 0, North);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        [Fact]
        public void Rover_Can_Move_Backward()
        {
            var startingPosition = new Position(1, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Backward });

            Position expectedPosition = new Position(0, 0, North);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        [Fact]
        public void Rover_Can_Move_Forward_And_Backward()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Forward, Forward, Forward, Forward, Backward, Backward });

            Position expectedPosition = new Position(2, 0, North);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        [Fact]
        public void Rover_Can_Turn_Left()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Left });

            Position expectedPosition = new Position(0, 0, West);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        [Fact]
        public void Rover_Can_Turn_Left_Multiple_Times()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Left, Left, Left });

            Position expectedPosition = new Position(0, 0, East);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        [Fact]
        public void Rover_Can_Turn_Right()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Right });

            Position expectedPosition = new Position(0, 0, East);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        [Fact]
        public void Rover_Can_Turn_Right_Multiple_Times()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Right, Right, Right });

            Position expectedPosition = new Position(0, 0, West);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        [Fact]
        public void Rover_Can_Turn_And_Move_In_Different_Direction()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(10, 10);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Forward, Forward, Forward, Right, Forward, Forward, Right, Backward, Backward });

            Position expectedPosition = new Position(5, 2, South);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        [Fact]
        public void Rover_Can_Go_Over_Grid_Boundary()
        {
            var startingPosition = new Position(0, 0, North);
            var pluto = new Grid(100, 100);
            var rover = new Rover(startingPosition, pluto);

            var report = rover.Move(new List<string> { Backward });

            Position expectedPosition = new Position(100, 0, North);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        [Fact]
        public void Rover_Can_Go_Over_Grid_Boundary_Both_Directions()
        {
            var startingPosition = new Position(0, 0, North);
            var grid = new Grid(250, 250);
            var rover = new Rover(startingPosition, grid);

            var report = rover.Move(new List<string> { Backward, Left, Forward });

            Position expectedPosition = new Position(250, 250, West);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
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

            Position expectedPosition = new Position(1, 2, North);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);
        }

        private void AssertPositionIsCorrect(Position expected, Position actual)
        {
            Assert.Equal(expected.YCoordinate, actual.YCoordinate);
            Assert.Equal(expected.XCoordinate, actual.XCoordinate);
            Assert.Equal(expected.Direction, actual.Direction);
        }
    }
}
