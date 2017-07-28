using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public sealed class CreateBoxerCommand : CreateOlympian
    {
        private readonly string category;
        private readonly int wins;
        private readonly int losses;

        public CreateBoxerCommand(IList<string> commandLine) : base(commandLine)
        {
            Validator.ValidateParametersCount(commandLine, 4);
            Validator.ValidateNumber(commandLine[4]);
            Validator.ValidateNumber(commandLine[5]);

            this.category = commandLine[3];
            this.wins = commandLine.Count > 4 ? int.Parse(commandLine[4]) : 0;
            this.losses = commandLine.Count > 5 ? int.Parse(commandLine[5]) : 0;
        }

        public override IOlympian CreatePerson()
        {
            return this.Factory.CreateBoxer(this.firstName, this.lastName, this.country, this.category, this.wins, this.losses);
        }
    }
}
