using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.OpinionPoll
{
    public class PoolOfPeople
    {
        private List<Person> membersList;

        public PoolOfPeople()
        {
            membersList = new List<Person>();
        }

        public void AddMember(Person member)
        {
            membersList.Add(member);
        }

        public List<Person> GetFilteredMembers()
        {
            var members = membersList
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();
            return members;
        }
    }
}
