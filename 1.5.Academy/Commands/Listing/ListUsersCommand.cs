using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        // TODO: Implement this
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {

            StringBuilder result = new StringBuilder();

            if (this.engine.Trainers.Any())
            {
                foreach (var trainer in this.engine.Trainers)
                {
                    result.AppendLine(trainer.ToString());
                }
            }

            if (this.engine.Students.Any())
            {
                foreach (var student in this.engine.Students)
                {
                    result.AppendLine(student.ToString());
                }
            }

            if (result.ToString().Equals(""))
            {
                return "There are no registered users!";
            }

            return result.ToString().TrimEnd();
        }
    }
}
