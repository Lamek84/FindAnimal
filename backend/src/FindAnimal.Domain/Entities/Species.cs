using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities
{
    public class Species : Entity
    {
        public Species() { }
        public string Name { get; private set; }
        public List<Breed> Breeds { get; private set; } = [];
    }
    
}
