using Traveller.Models.Contracts;

namespace Traveller.Models
{
    public class Ticket : ITicket
    {
        public Ticket(IJourney journey, decimal administrativeCosts)
        {
            this.Journey = journey;
            this.AdministrativeCosts = administrativeCosts;
        }

        public decimal AdministrativeCosts { get; private set; }

        public IJourney Journey { get; private set; }

        public decimal CalculatePrice()
        {
            decimal result = this.AdministrativeCosts + this.Journey.CalculateTravelCosts();

            return result;
        }

        public override string ToString()
        {
            return string.Format($"{this.GetType().Name} ----\nDestination: {this.Journey.Destination}\nPrice: {this.CalculatePrice()}");
        }
    }
}
