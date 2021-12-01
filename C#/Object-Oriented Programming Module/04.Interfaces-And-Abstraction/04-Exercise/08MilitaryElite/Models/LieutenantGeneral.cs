using MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldier> privates;
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privtes => (IReadOnlyCollection<ISoldier>)this.privates;

        public void AddPrivate(ISoldier soldier)
        {
            this.privates.Add(soldier);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var soldier in this.privates)
            {
                sb.AppendLine($"  {soldier.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
