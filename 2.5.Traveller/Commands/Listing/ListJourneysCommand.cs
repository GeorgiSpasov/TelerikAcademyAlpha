using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ICommand
    {
        private readonly IDatabase database;

        public ListJourneysCommand(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException("Traveller Database can't be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var journeys = this.database.Journeys;
            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
