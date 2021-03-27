namespace _03StudentSystem.Commands
{
    public interface ICommand
    {
        void Execute(string[] args, StudentsDatabase database);
    }
}
