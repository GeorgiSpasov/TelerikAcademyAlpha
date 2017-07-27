using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System.Collections.Generic;
using System.Linq;

namespace OlympicGames.Olympics
{
    public class Sprinter : Olympian, IOlympian, ISprinter
    {
        private IDictionary<string, double> personalRecords;

        public Sprinter(string firstName, string lastName, string country, IDictionary<string, double> personalRecords = null) : base(firstName, lastName, country)
        {
            this.PersonalRecords = personalRecords;
        }

        public IDictionary<string, double> PersonalRecords
        {
            get
            {
                return this.personalRecords;
            }
            set
            {
                this.personalRecords = value;
            }
        }

        public override string ToString()
        {
            return string.Format($"SPRINTER: {this.FirstName} {this.LastName} from {this.Country}\n{(this.personalRecords.Count == 0 ? GlobalConstants.NoPersonalRecordsSet : GlobalConstants.PersonalRecords + "\n" + string.Join("\n", this.personalRecords.Select(r => r.Key + "m: " + r.Value + "s")))}");
        }
    }
}
