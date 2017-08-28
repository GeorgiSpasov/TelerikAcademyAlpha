using System;
using System.Collections.Generic;
using Traveller.Commands.Abstracts;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Commands.Creating
{
    // TODO
    public class CreateAirplaneCommand : CreateVehicleCommand
    {
        public CreateAirplaneCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override IVehicle CreateVehicle(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            bool hasFreeFood;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                hasFreeFood = bool.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            var airplane = base.Factory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);

            return airplane;
        }
    }
}
