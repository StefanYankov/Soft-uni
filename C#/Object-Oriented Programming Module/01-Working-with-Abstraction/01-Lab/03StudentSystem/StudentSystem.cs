using _03StudentSystem.Commands;
using _03StudentSystem.IO;
using System.Collections.Generic;

namespace _03StudentSystem
{
    public class StudentSystem
    {
        private readonly IIOEngine ioEngine;
        private StudentsDatabase students;

        private Dictionary<string, ICommand> commands;

        public StudentSystem(IIOEngine ioEngine)
        {
            this.students = new StudentsDatabase();

            this.commands = new Dictionary<string, ICommand>
            {
                { "Create", new CreateCommand() },
                { "Show", new ShowCommand(ioEngine) }
            };
            this.ioEngine = ioEngine;
        }



        public void ParseCommand()
        {
            string[] args = this.ioEngine.Read().Split();
            var commandName = args[0];
            if (this.commands.ContainsKey(commandName))
            {
                var command = this.commands[commandName];
                command.Execute(args, this.students);
            }
            else if (commandName == "Exit")
            {
                return;
            }
        }
    }
}
