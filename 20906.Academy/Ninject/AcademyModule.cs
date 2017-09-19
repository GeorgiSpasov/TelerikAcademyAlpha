using Academy.Commands;
using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Listing;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Ninject.Modules;
using Ninject;

namespace Academy.Ninject
{
    public class AcademyModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();

            this.Bind<IAcademyFactory>().To<AcademyFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            this.Bind<ICommand>().To<AddStudentToCourseCommand>().Named("AddStudentToCourse");
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().Named("AddStudentToSeason");
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().Named("AddTrainerToSeason");

            this.Bind<ICommand>().To<CreateCourseCommand>().Named("CreateCourseInternal");
            this.Bind<ICommand>().To<CreateCourseResultCommand>().Named("CreateCourseResultInternal");
            this.Bind<ICommand>().To<CreateLectureCommand>().Named("CreateLectureInternal");
            this.Bind<ICommand>().To<CreateLectureResourceCommand>().Named("CreateLectureResourceInternal");
            this.Bind<ICommand>().To<CreateSeasonCommand>().Named("CreateSeasonInternal");
            this.Bind<ICommand>().To<CreateStudentCommand>().Named("CreateStudentInternal");
            this.Bind<ICommand>().To<CreateTrainerCommand>().Named("CreateTrainerInternal");

            this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().Named("ListCoursesInSeason");
            this.Bind<ICommand>().To<ListUsersCommand>().Named("ListUsers");
            this.Bind<ICommand>().To<ListUsersInSeasonCommand>().Named("ListUsersInSeason");

            this.Bind<ICommand>().To<CommandDecorator>().Named("CreateCourse").WithConstructorArgument(this.Kernel.Get<ICommand>("CreateCourseInternal"));
            this.Bind<ICommand>().To<CommandDecorator>().Named("CreateCourseResult").WithConstructorArgument(this.Kernel.Get<ICommand>("CreateCourseResultInternal"));
            this.Bind<ICommand>().To<CommandDecorator>().Named("CreateLecture").WithConstructorArgument(this.Kernel.Get<ICommand>("CreateLectureInternal"));
            this.Bind<ICommand>().To<CommandDecorator>().Named("CreateLectureResource").WithConstructorArgument(this.Kernel.Get<ICommand>("CreateLectureResourceInternal"));
            this.Bind<ICommand>().To<CommandDecorator>().Named("CreateSeason").WithConstructorArgument(this.Kernel.Get<ICommand>("CreateSeasonInternal"));
            this.Bind<ICommand>().To<CommandDecorator>().Named("CreateStudent").WithConstructorArgument(this.Kernel.Get<ICommand>("CreateStudentInternal"));
            this.Bind<ICommand>().To<CommandDecorator>().Named("CreateTrainer").WithConstructorArgument(this.Kernel.Get<ICommand>("CreateTrainerInternal"));
        }
    }
}
