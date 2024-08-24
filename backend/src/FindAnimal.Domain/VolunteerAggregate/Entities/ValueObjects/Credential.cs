using CSharpFunctionalExtensions;
using FindAnimal.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnimal.Domain.VolunteerAggregate.Entities.ValueObjects
{
    public class Credential : Shared.ValueObject
    {
        public string Title { get; }
        public string Description { get; }


        private Credential() { }
        private Credential(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public static Result<Credential> Create(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return Result.Failure<Credential>("Title name is empty.");
            }

            if (title.Length > Constants.MAX_TITLE_NAME_LENGTH)
            {
                return Result.Failure<Credential>("Title name is too long!");
            }

            return new Credential(title, description);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title;
            yield return Description;
        }
    }
}
