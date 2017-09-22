using System.Text;

namespace Traveller.Core.Contracts
{
    public interface ICommandProcessor
    {
        void ProcessCommand(string commandAsString, StringBuilder builder);
    }
}
