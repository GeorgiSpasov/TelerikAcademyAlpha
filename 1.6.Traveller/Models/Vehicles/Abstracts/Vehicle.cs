using System;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Models.Vehicles.Enums;

namespace Traveller.Models.Vehicles.Abstracts
{
    public abstract class Vehicle : IVehicle
    {
        private int passangerCapacity;
        private decimal pricePerKilometer;
        private VehicleType type;

        public Vehicle(int passangerCapacity, decimal pricePerKilometer)
        {
            this.PassangerCapacity = passangerCapacity;
            this.PricePerKilometer = pricePerKilometer;
        }

        public virtual int PassangerCapacity
        {
            get
            {
                return this.passangerCapacity;
            }
            protected set
            {
                if (value < 1 || value > 800)
                {
                    throw new ArgumentOutOfRangeException("A vehicle with less than 1 passengers or more than 800 passengers cannot exist!");
                }
                this.passangerCapacity = value;
            }
        }

        public decimal PricePerKilometer
        {
            get
            {
                return this.pricePerKilometer;
            }
            private set
            {
                if (value < 0.1M || value > 2.5M)
                {
                    throw new ArgumentOutOfRangeException("A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!");
                }
                this.pricePerKilometer = value;
            }
        }

        public VehicleType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public abstract string VehicleSpecificInfo();

        public override string ToString()
        {
            return string.Format($"{this.GetType().Name} ----\nPassenger capacity: {this.PassangerCapacity}\nPrice per kilometer: {this.PricePerKilometer}\nVehicle type: {this.Type}{this.VehicleSpecificInfo()}");
        }
    }
}
