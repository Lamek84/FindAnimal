using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities
{
    public class Breed : Entity
    {
        public Breed() { }
        public string Name { get; private set; }
        public Guid SpeciesId { get; private set; }
    }
}
