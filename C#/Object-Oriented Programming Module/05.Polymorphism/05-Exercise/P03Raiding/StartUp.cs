using P03Raiding.Core;
using P03Raiding.Core.Contracts;

namespace P03Raiding
{
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
