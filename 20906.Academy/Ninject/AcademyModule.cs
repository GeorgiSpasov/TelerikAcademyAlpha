using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Providers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Ninject
{
    public class AcademyModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            //this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IDatabase>().To<Database>().InSingletonScope();
        }
    }
}
