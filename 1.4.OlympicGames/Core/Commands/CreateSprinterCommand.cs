using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics;
using OlympicGames.Utils;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : Command, ICommand
    {
        // Consider using the dictionary
        private readonly IDictionary<string, double> records;
        private Sprinter sprinter;

        public CreateSprinterCommand(IList<string> commandLine) : base(commandLine)
        {
            Validator.ValidateParametersCount(commandLine, 3);

            this.records = new Dictionary<string, double>();
            if (commandLine.Count > 3)
            {
                for (int i = 3; i < commandLine.Count; i++)
                {
                    string[] recordData = commandLine[i].Split('/');
                    this.Records.Add(recordData[0], double.Parse(recordData[1]));
                }
            }

            sprinter = new Sprinter(commandLine[0], commandLine[1], commandLine[2], this.Records);
            this.Committee.Olympians.Add(sprinter);
        }

        public IDictionary<string, double> Records
        {
            get
            {
                return this.records;
            }
        }

        public override string Execute()
        {
            return string.Format("Created Sprinter\n" + this.sprinter);
        }
    }
}
