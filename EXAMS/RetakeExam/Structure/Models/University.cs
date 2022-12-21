using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private string universityName;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;
        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;
            this.requiredSubjects = requiredSubjects.ToList();
        }
        public int Id { get; private set; }

        public string Name
        {
            get { return universityName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                universityName = value;
            }

        }

        public string Category
        {
            get { return category; }
            private set
            {
                if (value != "Technical" && value != "Economical" && value != "Humanity")
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                category = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityNegative));
                }
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects => requiredSubjects;
    }
}
