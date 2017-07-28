using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public sealed class CreateSprinterCommand : CreateOlympian
    {
        // Consider using the dictionary
        private readonly IDictionary<string, double> records;

        public CreateSprinterCommand(IList<string> commandLine) : base(commandLine)
        {
            this.records = new Dictionary<string, double>();
            if (commandLine.Count > 3)
            {
                for (int i = 3; i < commandLine.Count; i++)
                {
                    string[] recordData = commandLine[i].Split('/');
                    this.Records.Add(recordData[0], double.Parse(recordData[1]));
                }
            }
        }

        public IDictionary<string, double> Records
        {
            get
            {
                return this.records;
            }
        }

        public override IOlympian CreatePerson()
        {
            return this.Factory.CreateSprinter(this.firstName, this.lastName, this.country, this.records);
        }
    }
}
