using Academy.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Commands
{
    public class CommandDecorator : ICommand
    {
        private ICommand command;

        public CommandDecorator(ICommand command)
        {
            this.command = command;
        }

        public string Execute(IList<string> parameters)
        {
            string commandResult = this.command.Execute(parameters);
            string decoration = $"Command is called at {DateTime.Now}!";
            string result = string.Format($"{commandResult}\n{decoration}");

            return result;
        }
    }
}
