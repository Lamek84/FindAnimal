using CSharpFunctionalExtensions;
using FindAnimal.Domain.SpeciesAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.VolunteerAggregate.Entities.ValueObjects
{
    public record SpeciesBreedType
    {
        public SpeciesId SpeciesId { get; }
        public BreedId BreedId { get; }


        private SpeciesBreedType() { }
        private SpeciesBreedType(SpeciesId speciesId, BreedId breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }
               
        public static Result<SpeciesBreedType> Create(SpeciesId speciesId, BreedId breedId)
        {
            return new SpeciesBreedType(speciesId, breedId);
        }

    }
}
