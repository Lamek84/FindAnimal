using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities
{
    public record PetId
    {
        private Guid Value { get; }
        private PetId(Guid value) 
        {
            Value = value;
        }

        public static PetId NewPetId() => new(Guid.NewGuid());
        public static PetId Empty() => new(Guid.Empty);
    }
}
