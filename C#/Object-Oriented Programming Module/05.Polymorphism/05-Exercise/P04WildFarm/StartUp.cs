using P04WildFarm.Core;
using P04WildFarm.Core.Contracts;

namespace P04WildFarm
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
