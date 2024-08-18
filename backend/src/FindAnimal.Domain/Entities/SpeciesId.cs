using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities
{
    public record SpeciesId
    {
        private Guid Value { get; }
        private SpeciesId(Guid value) 
        {
            Value = value;
        }

        public static SpeciesId NewPetId() => new(Guid.NewGuid());
        public static SpeciesId Empty() => new(Guid.Empty);
    }
}
