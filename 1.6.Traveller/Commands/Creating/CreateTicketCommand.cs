using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                journey = this.engine.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = this.factory.CreateTicket(journey, administrativeCosts);
            this.engine.Tickets.Add(ticket);

            return $"Ticket with ID {engine.Tickets.Count - 1} was created.";
        }
    }
}
