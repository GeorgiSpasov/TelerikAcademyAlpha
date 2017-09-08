using Academy.Models.Contracts;
using System.Collections.Generic;

namespace Academy.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IReader Reader { get; }
        IWriter Writer { get; }
        IParser Parser { get; }

        //IList<ISeason> Seasons { get; }
        //IList<IStudent> Students { get; }
        //IList<ITrainer> Trainers { get; }
    }
}
