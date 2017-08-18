using System.Collections.Generic;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Commands.Abstracts
{
    public abstract class CreateVehicleCommand : Command
    {
        protected int passengerCapacity;
        protected decimal pricePerKilometer;
        private IVehicle vehicle;

        public CreateVehicleCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public abstract IVehicle CreateVehicle(IList<string> parameters);

        public override string Execute(IList<string> parameters)
        {
            var vehicle = this.CreateVehicle(parameters);
            this.engine.Vehicles.Add(vehicle);

            return $"Vehicle with ID {engine.Vehicles.Count - 1} was created.";
        }
    }
}