using System;
using Traveller.Models.Vehicles.Abstracts;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Models.Vehicles.Enums;

namespace Traveller.Models.Vehicles
{
    public class Bus : Vehicle, IBus
    {
        public Bus(int passangerCapacity, decimal pricePerKilometer) : base(passangerCapacity, pricePerKilometer)
        {
            base.Type = VehicleType.Land;
        }

        public override int PassangerCapacity
        {
            get
            {
                return base.PassangerCapacity;
            }
            protected set
            {
                if (value < 10 || value > 50)
                {
                    throw new ArgumentOutOfRangeException("A bus cannot have less than 10 passengers or more than 50 passengers.");
                }
                base.PassangerCapacity = value;
            }
        }

        public override string VehicleSpecificInfo()
        {
            return "";
        }
    }
}
