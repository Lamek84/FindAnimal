using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnimal.Domain.Shared;

namespace FindAnimal.Domain.Entities
{
    public class Species : Entity<SpeciesId>
    {
        private readonly List<Breed> _breeds = [];

        public Species(SpeciesId id) :base(id) { }

        public Species(SpeciesId id, string name) : base(id) 
        {
            Name = name;
        }
        public string Name { get; private set; }
        public List<Breed> Breeds { get; private set; } = [];

        private void AddBreeds(List<Breed> breeds)
        {
            _breeds.AddRange(breeds);
        }
    }
    
}
