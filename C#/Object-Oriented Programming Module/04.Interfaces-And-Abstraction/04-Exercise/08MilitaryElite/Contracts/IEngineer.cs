using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
        public void AddRepair(IRepair repair);
    }
}
