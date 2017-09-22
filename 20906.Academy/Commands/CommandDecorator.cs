using Academy.Commands.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Commands
{
    public class CommandDecorator : ICommand
    {
        private readonly ICommand command;

        public CommandDecorator(ICommand command)
        {
            this.command = command ?? throw new ArgumentNullException("Command cannot be null!");
        }

        public string Execute(IList<string> parameters)
        {
            string commandResult = this.command.Execute(parameters);
            string decoration = $"Command is called at {DateTime.Now}!";
            string result = string.Format($"{commandResult} [{decoration}]");

            return result;
        }
    }
}
