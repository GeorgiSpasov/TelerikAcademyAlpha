using System.Collections.Generic;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core
{
    public class Database : IDatabase
    {
        private readonly IList<IVehicle> vehicles;
        private readonly IList<IJourney> journeys;
        private readonly IList<ITicket> tickets;

        public Database()
        {
            this.vehicles = new List<IVehicle>();
            this.journeys = new List<IJourney>();
            this.tickets = new List<ITicket>();
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
        }

        public IList<IJourney> Journeys
        {
            get
            {
                return this.journeys;
            }
        }

        public IList<ITicket> Tickets
        {
            get
            {
                return this.tickets;
            }
        }
    }
}
