using Academy.Core.Contracts;
using Bytes2you.Validation;
using System;
using System.Text;

namespace Academy.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandParser commandParser;
        private readonly ICommandProcessor commandProcessor;

        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private readonly StringBuilder builder = new StringBuilder();

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser, ICommandProcessor commandProcessor)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(commandParser, "commandParser").IsNull().Throw();
            Guard.WhenArgument(commandProcessor, "commandProcessor").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
            this.commandProcessor = commandProcessor;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();
                    if (commandAsString == TerminationCommand)
                    {
                        this.writer.Write(this.builder.ToString());
                        break;
                    }

                    this.commandProcessor.ProcessCommand(commandAsString, builder);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.builder.AppendLine("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }
    }
}
