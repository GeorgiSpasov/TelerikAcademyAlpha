using System;
using System.Collections.Generic;
using Traveller.Commands.Abstracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : Command
    {
        public CreateBusCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            var bus = this.factory.CreateBus(passengerCapacity, pricePerKilometer);
            this.engine.Vehicles.Add(bus);

            return $"Vehicle with ID {engine.Vehicles.Count - 1} was created.";
        }

    }
}
