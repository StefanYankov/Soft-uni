using P02Vehicles_Extension.Core;
using P02Vehicles_Extension.Core.Contracts;

namespace P02Vehicles_Extension
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
