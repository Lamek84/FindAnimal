using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using FindAnimal.Domain.Shared;
using FindAnimal.Domain.VolunteerAggregate.Entities;

namespace FindAnimal.Domain.SpeciesAggregate.Entities
{
    public class Species : Shared.Entity<SpeciesId>
    {
        private Species(SpeciesId id) : base(id) { }
        private Species(SpeciesId id, string name) : base(id)
        {
            Name = name;
        }


        private readonly List<Breed> _breeds = [];
        public string Name { get; private set; }
        public IReadOnlyList<Breed> Breeds => _breeds;

        
        public void AddBreeds(List<Breed> breeds)
        {
            _breeds.AddRange(breeds);
        }

        public static Result<Species> Create(SpeciesId id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Species>($"Invalid name {nameof(name)} cannot be null or empty");
            }

            var species = new Species(id, name);

            return species;
        }
    }

}
