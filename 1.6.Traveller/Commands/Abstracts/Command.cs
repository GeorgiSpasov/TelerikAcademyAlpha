using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IEngine engine;

        public Command(ITravellerFactory factory, IEngine engine)
        {
            this.Factory = factory;
            this.Engine = engine;
        }

        public ITravellerFactory Factory { get; private set; }

        public IEngine Engine { get; private set; }

        public abstract string Execute(IList<string> parameters);
    }
}