using Ninject;
using Traveller.Core.Contracts;
using Traveller.Ninject;

namespace Traveller
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new TravellerModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
