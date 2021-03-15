using P01Vehicles.Core;
using P01Vehicles.Core.Contracts;

namespace P01Vehicles
{
    public class Startup
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
