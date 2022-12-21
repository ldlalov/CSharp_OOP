using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private List<Person> firstTeam = new List<Person>();
        private List<Person> reserveTeam = new List<Person>();
        public Team(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public IReadOnlyCollection<Person> FirstTeam => firstTeam;
        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam;

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"First team has {FirstTeam.Count} players.");
            sb.Append($"Reserve team has {ReserveTeam.Count} players.");
            return sb.ToString();
        }
    }
}
