using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }

        public void CompleteMission();
    }
}
