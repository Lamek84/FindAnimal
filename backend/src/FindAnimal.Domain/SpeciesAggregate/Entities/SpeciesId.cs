using FindAnimal.Domain.VolunteerAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.SpeciesAggregate.Entities
{
    public record SpeciesId
    {
        public Guid Value { get; }
        private SpeciesId(Guid value)
        {
            Value = value;
        }

        public static SpeciesId NewSpeciesId() => new(Guid.NewGuid());
        public static SpeciesId Empty() => new(Guid.Empty);
        public static SpeciesId Create(Guid id) => new(id);
    }
}
