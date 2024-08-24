using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.VolunteerAggregate.Entities
{
    public record PetId
    {
        public Guid Value { get; }

        private PetId(Guid value)
        {
            Value = value;
        }

        public static PetId NewPetId() => new(Guid.NewGuid());
        public static PetId Empty() => new(Guid.Empty);
        public static PetId Create(Guid id) => new(id);
    }
}
