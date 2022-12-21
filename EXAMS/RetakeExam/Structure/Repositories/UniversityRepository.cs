using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    internal class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> universities;
            public UniversityRepository()
        {
            universities = new List<IUniversity>();
        }
        public IReadOnlyCollection<IUniversity> Models => universities;

        public void AddModel(IUniversity model)
        {
            universities.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return universities.FirstOrDefault(f => f.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return universities.FirstOrDefault(f => f.Name == name);
        }
    }
}
