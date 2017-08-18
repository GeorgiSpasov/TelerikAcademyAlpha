using System;
using System.Collections.Generic;
using Traveller.Commands.Abstracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    // TODO
    public class CreateAirplaneCommand : Command
    {
        public CreateAirplaneCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
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

            var airplane = this.factory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            this.engine.Vehicles.Add(airplane);

            return $"Vehicle with ID {engine.Vehicles.Count - 1} was created.";
        }
    }
}
