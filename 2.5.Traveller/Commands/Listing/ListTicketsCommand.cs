using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : ICommand
    {
        private readonly IDatabase database;

        public ListTicketsCommand(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException("Traveller Database can't be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var tickets = this.database.Tickets;
            if (tickets.Count == 0)
            {
                return "There are no registered tickets.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, tickets);
        }
    }
}
