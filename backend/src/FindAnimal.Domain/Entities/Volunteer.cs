using FindAnimal.Domain.Enums;
using FindAnimal.Domain.Shared;
using CSharpFunctionalExtensions;
using Microsoft.VisualBasic;
using FindAnimal.Domain.Entities.ValueObjects;

namespace FindAnimal.Domain.Entities
{
    public class Volunteer : Shared.Entity<VolunteerId>
    {
        private readonly List<Pet> _pets = [];

        // ef core
        private Volunteer(VolunteerId id) :base(id) { }

        private Volunteer(VolunteerId volunteerId, 
            string fullName, 
            string description, 
            int yearsExperience, 
            string phone, 
            List<SocialNetwork> socialNetworks, 
            List<Credentials> credentials) : base(volunteerId)
        {
            PersonFullName = fullName;
            Description = description;
            YearsOfExperience = yearsExperience;
            Phone = phone;
            SocialNetworks = socialNetworks;
            Credentials = credentials;
        }
        public string PersonFullName { get; private set; }
        public string Description { get; private set; }
        public int YearsOfExperience { get; private set; }
        public int GetNumberOfPetFoundeHome() => _pets.Count(p => p.HelpStatus == HelpStatus.FoundHome);
        public int GetNumberOfPetLookingHome() => _pets.Count(p => p.HelpStatus == HelpStatus.LookingHome);
        public int GetNumberOfPetInTreatment() => _pets.Count(p => p.HelpStatus == HelpStatus.NeedsHelp);
        public string Phone { get; private set; }
        public List<SocialNetwork> SocialNetworks { get; private set; }
        public List<Credentials> Credentials { get; private set; }
        public IReadOnlyList<Pet> Pets => _pets;


        private void AddPets(List<Pet> pets)
        {
            _pets.AddRange(pets);
        }

        public static Result<Volunteer> Create(VolunteerId volunteerId, string fullName, string description, int yearsExperience, string phone, 
            List<SocialNetwork> socialNetworks, List<Credentials> credentials)
        {
            if (string.IsNullOrWhiteSpace(description) || description.Length > Shared.Constants.MAX_LONG_TEXT_LENGTH)
                return Result.Failure<Volunteer>($"Invalid description {nameof(description)} cannot be null or empty or longer than {Shared.Constants.MAX_LONG_TEXT_LENGTH} characters.");

            if (yearsExperience < Shared.Constants.MIN_VALUE)
                return Result.Failure<Volunteer>($"Invalid experience {nameof(yearsExperience)} cannot be less than {Shared.Constants.MIN_VALUE}.");

            var volunteer = new Volunteer(volunteerId, fullName, description, yearsExperience, phone, socialNetworks, credentials);

            return Result.Success(volunteer);
        }
    }
}
