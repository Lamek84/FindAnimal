using FindAnimal.Domain.VolunteerAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.SpeciesAggregate.Entities
{
    public record BreedId
    {
        public Guid Value { get; }
        private BreedId(Guid value)
        {
            Value = value;
        }

        public static BreedId NewBreedId() => new(Guid.NewGuid());
        public static BreedId Empty() => new(Guid.Empty);
        public static BreedId Create(Guid id) => new(id);
    }
}
