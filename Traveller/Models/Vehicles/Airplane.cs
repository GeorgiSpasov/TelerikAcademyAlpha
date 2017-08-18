using Traveller.Models.Vehicles.Abstracts;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Models.Vehicles.Enums;

namespace Traveller.Models.Vehicles
{
    public class Airplane : Vehicle, IAirplane
    {
        public Airplane(int passangerCapacity, decimal pricePerKilometer, bool hasFreeFood) : base(passangerCapacity, pricePerKilometer)
        {
            base.Type = VehicleType.Air;
            this.HasFreeFood = hasFreeFood;
        }

        public bool HasFreeFood { get; private set; }

        public override string VehicleSpecificInfo()
        {
            return string.Format($"\nHas free food: {this.HasFreeFood}");
        }
    }
}
