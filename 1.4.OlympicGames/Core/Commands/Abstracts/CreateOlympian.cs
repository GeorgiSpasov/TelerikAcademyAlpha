using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class CreateOlympian : Command
    {
        protected readonly string firstName;
        protected readonly string lastName;
        protected readonly string country;
        private IOlympian olympian;

        public CreateOlympian(IList<string> commandLine) : base(commandLine)
        {
            Validator.ValidateParametersCount(commandLine, 3);

            this.firstName = commandLine[0];
            this.lastName = commandLine[1];
            this.country = commandLine[2];
        }

        public abstract IOlympian CreatePerson();

        public override string Execute()
        {
            this.olympian = this.CreatePerson();
            this.Committee.Olympians.Add(this.olympian);
            return string.Format($"Created {this.olympian.GetType().Name}\n{this.olympian}");
        }
    }
}
