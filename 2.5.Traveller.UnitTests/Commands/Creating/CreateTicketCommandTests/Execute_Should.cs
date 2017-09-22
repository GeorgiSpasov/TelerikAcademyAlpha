using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Traveller.Commands.Creating;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;

namespace Traveller.UnitTests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateTicketAndAddItToDatabase_WhenParametersAreCorrect()
        {
            // Arrange
            string journeyID = "0";
            string administrativeCosts = "50";
            List<string> parameters = new List<string>()
            {
                journeyID,
                administrativeCosts
            };

            var journeyMock = new Mock<IJourney>();

            List<ITicket> tickets = new List<ITicket>();
            List<IJourney> journeys = new List<IJourney>();
            journeys.Add(journeyMock.Object);


            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();
            var ticketMock = new Mock<ITicket>();

            databaseMock.SetupGet(m => m.Tickets).Returns(tickets);
            databaseMock.SetupGet(m => m.Journeys).Returns(journeys);

            factoryMock.Setup(m => m.CreateTicket(journeyMock.Object, It.IsAny<decimal>())).Returns(ticketMock.Object);

            var command = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act
            command.Execute(parameters);

            // Assert
            Assert.AreEqual(1, databaseMock.Object.Tickets.Count);
            Assert.AreSame(ticketMock.Object, databaseMock.Object.Tickets.Single());
        }

        [TestMethod]
        [DataRow("notAnInt", "50")]
        [DataRow("0", "notADecimal")]
        public void ThrowArgumentException_WhenParametersAreNotCorrect(string journeyParam, string administrativeCostsParam)
        {
            // Arrange
            string journeyID = journeyParam;
            string administrativeCosts = administrativeCostsParam;
            List<string> parameters = new List<string>()
            {
                journeyID,
                administrativeCosts
            };

            var journeyMock = new Mock<IJourney>();

            List<ITicket> tickets = new List<ITicket>();
            List<IJourney> journeys = new List<IJourney>();
            journeys.Add(journeyMock.Object);


            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();
            var ticketMock = new Mock<ITicket>();

            databaseMock.SetupGet(m => m.Tickets).Returns(tickets);
            databaseMock.SetupGet(m => m.Journeys).Returns(journeys);

            factoryMock.Setup(m => m.CreateTicket(journeyMock.Object, It.IsAny<decimal>())).Returns(ticketMock.Object);

            var command = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute(parameters));
        }

        [TestMethod]
        [DataRow("100", "50")]
        public void ThrowArgumentOutOfRangeException_WhenJourneyIsNotInDatabase(string journeyParam, string administrativeCostsParam)
        {
            // Arrange
            string journeyID = journeyParam;
            string administrativeCosts = administrativeCostsParam;
            List<string> parameters = new List<string>()
            {
                journeyID,
                administrativeCosts
            };

            var journeyMock = new Mock<IJourney>();

            List<ITicket> tickets = new List<ITicket>();
            List<IJourney> journeys = new List<IJourney>();
            journeys.Add(journeyMock.Object);


            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();
            var ticketMock = new Mock<ITicket>();

            databaseMock.SetupGet(m => m.Tickets).Returns(tickets);
            databaseMock.SetupGet(m => m.Journeys).Returns(journeys);

            factoryMock.Setup(m => m.CreateTicket(journeyMock.Object, It.IsAny<decimal>())).Returns(ticketMock.Object);

            var command = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => command.Execute(parameters));
        }
    }
}
