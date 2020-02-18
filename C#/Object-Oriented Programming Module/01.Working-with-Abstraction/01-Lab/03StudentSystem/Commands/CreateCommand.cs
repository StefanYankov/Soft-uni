namespace _03StudentSystem.Commands
{
    public class CreateCommand : ICommand
    {
        public void Execute(string[] args, StudentsDatabase database)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);
            database.Add(name, age, grade);
        }
    }
}
