using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using OlympicGames.Utils;
using System;
using System.Linq;

namespace OlympicGames.Olympics
{
    public class Boxer : Olympian, IOlympian, IBoxer
    {
        private BoxingCategory category;
        private int wins;
        private int losses;

        public Boxer(string firstName, string lastName, string country, BoxingCategory category, int wins = 0, int losses = 0) : base(firstName, lastName, country)
        {
            this.Category = category;
            this.Wins = wins;
            this.Losses = losses;
        }

        public BoxingCategory Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                this.category = value;
            }
        }

        public int Wins
        {
            get
            {
                return this.wins;
            }
            private set
            {
                //if (!value.ToString().All(char.IsDigit))
                //{
                //    throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
                //}
                Validator.ValidateNumber(value);
                Validator.ValidateMinAndMaxNumber(value, 0, 100, "Wins must be between 0 and 100!");
                this.wins = value;
            }
        }

        public int Losses
        {
            get
            {
                return this.losses;
            }
            private set
            {
                //if (!value.ToString().All(char.IsDigit))
                //{
                //    throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
                //}
                Validator.ValidateNumber(value);
                Validator.ValidateMinAndMaxNumber(value, 0, 100, "Losses must be between 0 and 100!");
                this.losses = value;
            }
        }

        public override string ToString()
        {
            return string.Format($"BOXER: {this.FirstName} {this.LastName} from {this.Country}\nCategory: {this.Category}\nWins: {this.Wins}\nLosses: {this.Losses}");
        }
    }
}
