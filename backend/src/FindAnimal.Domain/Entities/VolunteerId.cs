using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities
{
    public record VolunteerId
    {
        private Guid Value { get; }
        private VolunteerId(Guid value) 
        {
            Value = value;
        }

        public static VolunteerId NewVolunteerId() => new(Guid.NewGuid());
        public static VolunteerId Empty() => new(Guid.Empty);
    }
}
