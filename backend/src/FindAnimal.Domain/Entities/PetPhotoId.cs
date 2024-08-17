using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities
{
    public record PetPhotoId
    {
        private Guid Value { get; }
        private PetPhotoId(Guid value) 
        {
            Value = value;
        }

        public static PetPhotoId NewPetPhotoId() => new(Guid.NewGuid());
        public static PetPhotoId Empty() => new(Guid.Empty);
    }
}
