using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities
{
    public record BreedId
    {
        private Guid Value { get; }
        private BreedId(Guid value) 
        {
            Value = value;
        }

        public static BreedId NewPetId() => new(Guid.NewGuid());
        public static BreedId Empty() => new(Guid.Empty);
    }
}
