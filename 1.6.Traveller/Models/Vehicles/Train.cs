using System;
using Traveller.Models.Vehicles.Abstracts;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Models.Vehicles.Enums;

namespace Traveller.Models.Vehicles
{
    public class Train : Vehicle, ITrain
    {
        private int carts;

        public Train(int passangerCapacity, decimal pricePerKilometer, int carts) : base(passangerCapacity, pricePerKilometer)
        {
            base.Type = VehicleType.Land;
            this.Carts = carts;
        }

        public override int PassangerCapacity
        {
            get
            {
                return base.PassangerCapacity;
            }
            protected set
            {
                if (value < 30 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("A train cannot have less than 30 passengers or more than 150 passengers.");
                }
                base.PassangerCapacity = value;
            }
        }

        public int Carts
        {
            get
            {
                return this.carts;
            }
            protected set
            {
                if (value < 1 || value > 15)
                {
                    throw new ArgumentOutOfRangeException("A train cannot have less than 1 cart or more than 15 carts.");
                }
                this.carts = value;
            }
        }

        public override string VehicleSpecificInfo()
        {
            return string.Format($"\nCarts amount: {this.Carts}");
        }
    }
}
