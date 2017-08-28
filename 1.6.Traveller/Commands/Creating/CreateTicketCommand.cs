using System;
using System.Collections.Generic;
using Traveller.Commands.Abstracts;
using Traveller.Core.Contracts;
using Traveller.Models.Contracts;

namespace Traveller.Commands.Creating
{
    // TODO
    public class CreateTicketCommand : Command
    {
        public CreateTicketCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                journey = base.Engine.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = base.Factory.CreateTicket(journey, administrativeCosts);
            base.Engine.Tickets.Add(ticket);

            return $"Ticket with ID {Engine.Tickets.Count - 1} was created.";
        }
    }
}
