using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities
{
    public class PetPhoto
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Path { get; private set; }
        public bool IsMain { get; private set; }
    }
}
