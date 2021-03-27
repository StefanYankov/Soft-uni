using _03StudentSystem.IO;

namespace _03StudentSystem.Commands
{
    public class ShowCommand : ICommand
    {
        private readonly IIOEngine engine;
        public ShowCommand(IIOEngine engine)
        {
            this.engine = engine;
        }
        public void Execute(string[] args, StudentsDatabase database)
        {
            var name = args[1];
            var student = database.Find(name);
            if (student != null)
            {
                this.engine.Write(student.ToString());
            }
        }
    }
}
