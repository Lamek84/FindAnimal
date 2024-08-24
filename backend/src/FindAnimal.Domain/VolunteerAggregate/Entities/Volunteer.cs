using FindAnimal.Domain.Enums;
using FindAnimal.Domain.Shared;
using CSharpFunctionalExtensions;
using Microsoft.VisualBasic;
using FindAnimal.Domain.VolunteerAggregate.Entities.ValueObjects;

namespace FindAnimal.Domain.VolunteerAggregate.Entities
{
    public class Volunteer : Shared.Entity<VolunteerId>
    {
        private readonly List<Pet> _pets = [];

        // ef core
        private Volunteer(VolunteerId id) : base(id) { }
        private Volunteer(
            VolunteerId id,
            PersonFullName fullName,
            string description,
            int yearsExperience,
            PhoneNumber phone,
            SocialNetworkList socialNetworks,
            CredentialList credentials) : base(id)
        {
            PersonFullName = fullName;
            Description = description;
            YearsOfExperience = yearsExperience;
            Phone = phone;
            SocialNetworks = socialNetworks;
            Credentials = credentials;
        }

        public PersonFullName PersonFullName { get; private set; }
        public string Description { get; private set; }
        public int YearsOfExperience { get; private set; }
        public PhoneNumber Phone { get; private set; }
        public SocialNetworkList SocialNetworks { get; private set; }
        public CredentialList Credentials { get; private set; }
        public IReadOnlyList<Pet> Pets => _pets;

        public int GetNumberOfPetFoundeHome() => _pets.Count(p => p.HelpStatus == HelpStatus.FoundHome);
        public int GetNumberOfPetLookingHome() => _pets.Count(p => p.HelpStatus == HelpStatus.LookingHome);
        public int GetNumberOfPetInTreatment() => _pets.Count(p => p.HelpStatus == HelpStatus.NeedsHelp);
        public void AddPets(List<Pet> pets)
        {
            _pets.AddRange(pets);
        }

        public static Result<Volunteer> Create(VolunteerId volunteerId, PersonFullName fullName, string description,
            int yearsExperience, PhoneNumber phone, SocialNetworkList socialNetworks, CredentialList credentials)
        {
            if (string.IsNullOrWhiteSpace(description) || description.Length > Shared.Constants.MIDDLE_TEXT_LENGTH)
                return Result.Failure<Volunteer>($"Invalid description {nameof(description)} cannot be null or empty or longer than {Shared.Constants.MIDDLE_TEXT_LENGTH} characters.");

            if (yearsExperience < Shared.Constants.MIN_VALUE)
                return Result.Failure<Volunteer>($"Invalid experience {nameof(yearsExperience)} cannot be less than {Shared.Constants.MIN_VALUE}.");

            var volunteer = new Volunteer(volunteerId, fullName, description, yearsExperience, phone, socialNetworks, credentials);

            return Result.Success(volunteer);
        }
    }
}
