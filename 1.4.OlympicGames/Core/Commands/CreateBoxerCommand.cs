using System;
using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Olympics;
using OlympicGames.Olympics.Enums;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : Command, ICommand
    {
        private Boxer boxer;
        public CreateBoxerCommand(IList<string> commandLine) : base(commandLine)
        {
            Validator.ValidateParametersCount(commandLine, 4);

            boxer = new Boxer(commandLine[0],
                commandLine[1], commandLine[2],
                (BoxingCategory)Enum.Parse(typeof(BoxingCategory), commandLine[3], true),
                commandLine.Count > 4 ? int.Parse(commandLine[4]) : 0,
                commandLine.Count > 5 ? int.Parse(commandLine[5]) : 0);

            this.Committee.Olympians.Add(boxer);
        }

        public override string Execute()
        {
            return string.Format("Created Boxer\n" + this.boxer);
        }
    }
}
