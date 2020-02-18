using _03StudentSystem.IO;

namespace _03StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem(new ConsoleIOEngine());
            while (true)
            {
                studentSystem.ParseCommand();
            }
        }
    }
}
