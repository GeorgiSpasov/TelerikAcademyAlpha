using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Olympics
{
    public abstract class Olympian : IOlympian
    {
        private string firstName;
        private string lastName;
        private string country;

        public Olympian(string firstName, string lastName, string country)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Validator.ValidateIfNull(value, "First name cannot be null!");
                Validator.ValidateMinAndMaxLength(value, 2, 20, "First name must be between 2 and 20 characters long!");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validator.ValidateIfNull(value, "Last name cannot be null!");
                Validator.ValidateMinAndMaxLength(value, 2, 20, "Last name must be between 2 and 20 characters long!");
                this.lastName = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                Validator.ValidateIfNull(value, "Country cannot be null!");
                Validator.ValidateMinAndMaxLength(value, 3, 25, "Country must be between 3 and 25 characters long!");
                this.country = value;
            }
        }

        public abstract string OlympianSpecific();

        public override string ToString()
        {
            return string.Format($"{this.GetType().Name.ToUpper()}: {this.FirstName} {this.LastName} from {this.Country}\n{this.OlympianSpecific()}");
        }
    }
}
