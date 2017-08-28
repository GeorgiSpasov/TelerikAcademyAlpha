using System.Collections.Generic;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Commands.Abstracts
{
    public abstract class CreateVehicleCommand : Command
    {
        private int passengerCapacity;
        private decimal pricePerKilometer;
        private IVehicle vehicle;

        public CreateVehicleCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public int PassengerCapacity { get; set; }

        public decimal PricePerKilometer { get; set; }

        public abstract IVehicle CreateVehicle(IList<string> parameters);

        public override string Execute(IList<string> parameters)
        {
            var vehicle = this.CreateVehicle(parameters);
            base.Engine.Vehicles.Add(vehicle);

            return $"Vehicle with ID {Engine.Vehicles.Count - 1} was created.";
        }
    }
}