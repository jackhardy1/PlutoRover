using Xunit;
using System.Collections.Generic;
using Newtonsoft.Json;
using static PlutoRover.Directions;
using System;
using RestSharp;

namespace PlutoRover.API.Tests
{
    public class PlutoRoverApiTests
    {
        private RestClient client = new RestClient("https://localhost:5001/api/rover");

        [Fact]
        public void Rover_Carries_Out_All_Commands()
        {
            var position = new Position(0, 0, "N");
            var grid = new Grid(100, 100);
            var commands = new List<string> { "F", "R", "F", "F", "F", "L" };

            var requestBody = new CommandsRequest
            {
                startingPosition = position,
                grid = grid,
                commands = commands
            };

            Report report = this.GetReport(requestBody);

            Position expectedPosition = new Position(1, 3, North);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);

            Assert.False(report.EncounteredObstacle);
            Assert.Equal("Successfully carried out all commands", report.Message);
        }

        [Fact]
        public void Rover_Encounters_An_Obstacle()
        {
            var position = new Position(0, 0, "N");
            var obstacles = new List<Coordinates> { new Coordinates(1, 1), new Coordinates(2,5) };
            var grid = new Grid(100, 100, obstacles);
            var commands = new List<string> { "F", "R", "F", "F", "F", "L" };

            var requestBody = new CommandsRequest
            {
                startingPosition = position,
                grid = grid,
                commands = commands
            };

            Report report = this.GetReport(requestBody);

            Position expectedPosition = new Position(1, 0, East);

            this.AssertPositionIsCorrect(expectedPosition, report.FinalPosition);

            Assert.True(report.EncounteredObstacle);
            Assert.Equal("An obstacle was encountered at position: X 1, Y 1", report.Message);
        }

        private Report GetReport(CommandsRequest requestBody)
        {
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(requestBody);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Report report = JsonConvert.DeserializeObject<Report>(content);

            return report;
        }

        private void AssertPositionIsCorrect(Position expected, Position actual)
        {
            Assert.Equal(expected.YCoordinate, actual.YCoordinate);
            Assert.Equal(expected.XCoordinate, actual.XCoordinate);
            Assert.Equal(expected.Direction, actual.Direction);
        }
    }
}
