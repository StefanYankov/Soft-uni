using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privtes { get; }

        void AddPrivate(ISoldier soldier);
    }
}
