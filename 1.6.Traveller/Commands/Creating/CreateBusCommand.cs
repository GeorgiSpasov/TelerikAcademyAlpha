﻿using System;
using System.Collections.Generic;
using Traveller.Commands.Abstracts;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : CreateVehicleCommand
    {
        public CreateBusCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override IVehicle CreateVehicle(IList<string> parameters)
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

            var bus = base.Factory.CreateBus(passengerCapacity, pricePerKilometer);

            return bus;
        }
    }
}
