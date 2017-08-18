// Pesho?
// Ko? Ne..

using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected readonly ITravellerFactory factory;
        protected readonly IEngine engine;

        public Command(ITravellerFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public abstract string Execute(IList<string> parameters);
    }
}