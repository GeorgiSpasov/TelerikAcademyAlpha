using System;
using System.Text;
using Traveller.Core.Contracts;

namespace Traveller.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser commandParser;
        private readonly ICommandProcessor commandProcessor;

        private StringBuilder builder = new StringBuilder();

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser, ICommandProcessor commandProcessor)
        {
            this.reader = reader ?? throw new ArgumentNullException("Reader can't be null!");
            this.writer = writer ?? throw new ArgumentNullException("Writer can't be null!");
            this.commandParser = commandParser ?? throw new ArgumentNullException("Command Parser can't be null!");
            this.commandProcessor = commandProcessor ?? throw new ArgumentNullException("Command Processor can't be null!");
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();
                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        this.writer.Write(this.builder.ToString());
                        break;
                    }

                    this.commandProcessor.ProcessCommand(commandAsString, this.builder);
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }
    }
}
