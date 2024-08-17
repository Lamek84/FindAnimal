using FindAnimal.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.Entities.ValueObjects
{
    public class Credentials : ValueObject
    {
        public string Title { get; }
        public string Description { get; }
        private Credentials(){}

        private Credentials(string title, string description)
        {
            Title = title;
            Description = description;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title;
            yield return Description;
        }
    }
}
