using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindAnimal.Domain.Shared;

namespace FindAnimal.Domain.Entities
{
    public class Breed : Entity<BreedId>
    {
        private Breed(BreedId id):base(id) { }

        private Breed(BreedId id, string name, SpeciesId speciesId) : base(id)
        {
            Name = name;
            SpeciesId = speciesId;
        }
        public string Name { get; private set; }
        public SpeciesId SpeciesId { get; private set; }
    }
}
