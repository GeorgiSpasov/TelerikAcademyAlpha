using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ICommand
    {
        private readonly IDatabase database;

        public ListVehiclesCommand(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException("Traveller Database can't be null!");
        }

        public string Execute(IList<string> parameters)
        {
            var vehicles = this.database.Vehicles;
            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}
