using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private List<Person> firstSquad;
        private List<Person> reserveSquad;

        public Team(string name)
        {
            this.Name = name;
            this.firstSquad = new List<Person>();
            this.reserveSquad = new List<Person>();
        }

        public string Name { get; }

        public IReadOnlyList<Person> FirstSquad => this.firstSquad.AsReadOnly();

        public IReadOnlyList<Person> ReserveSquad
        {
            get
            {
                return this.reserveSquad.AsReadOnly();
            }
        }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                this.firstSquad.Add(player);
            }
            else
            {
                this.reserveSquad.Add(player);
            }
        }
    }
}
