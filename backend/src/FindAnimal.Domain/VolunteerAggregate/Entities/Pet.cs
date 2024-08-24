using CSharpFunctionalExtensions;
using FindAnimal.Domain.Enums;
using FindAnimal.Domain.Shared;
using FindAnimal.Domain.SpeciesAggregate.Entities;
using FindAnimal.Domain.VolunteerAggregate.Entities.ValueObjects;

namespace FindAnimal.Domain.VolunteerAggregate.Entities
{
    public class Pet : Shared.Entity<PetId>
    {
        private Pet(PetId id) : base(id) { }
        private Pet(
            PetId id,
            string name,
            SpeciesBreedType animalType,
            string description,
            string color,
            string healthInfo,
            Address address,
            double height,
            double weight,
            PhoneNumber contactNumber,
            DateOnly birthDate,
            bool isCastrated,
            bool isVaccinated,
            HelpStatus helpStatus,
            CredentialList credentials) : base(id)
        {
            Name = name;
            AnimalType = animalType;
            Description = description;
            Color = color;
            HelthInformation = healthInfo;
            LocationAddress = address;
            Height = height;
            Weigth = weight;
            ContactNumber = contactNumber;
            BirthDate = birthDate;
            IsCastrated = isCastrated;
            IsVaccinated = isVaccinated;
            HelpStatus = helpStatus;
            Credentials = credentials;
        }


        private readonly List<PetPhoto> _photos = [];
        public string Name { get; private set; } = string.Empty;
        public SpeciesBreedType AnimalType { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public string Color { get; private set; } = string.Empty;
        public string HelthInformation { get; private set; } = string.Empty;
        public Address LocationAddress { get; private set; }
        public double Height { get; private set; }
        public double Weigth { get; private set; }
        public PhoneNumber ContactNumber { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public bool IsCastrated { get; private set; }
        public bool IsVaccinated { get; private set; }
        public HelpStatus HelpStatus { get; private set; }
        public IReadOnlyList<PetPhoto> Photos => _photos;
        public CredentialList Credentials { get; private set; }



        public void AddPetPhotos(List<PetPhoto> petsPhoto)
        {
            _photos.AddRange(petsPhoto);
        }

        public static Result<Pet> Create(PetId petId, string name, SpeciesBreedType animalType, string description, string color, string healthInfo, Address address,
            double height, double weight, PhoneNumber contactNumber, DateOnly birthDate, bool isCastrated, bool isVaccinated, HelpStatus helpStatus, CredentialList credentials)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.MIN_TEXT_LENGTH)
                return Result.Failure<Pet>($"Invalid name {nameof(name)} cannot be null or empty or longer than {Constants.MIN_TEXT_LENGTH} characters.");

            var pet = new Pet(petId, name, animalType, description, color, healthInfo, address, height, weight, contactNumber, birthDate,
                            isCastrated, isVaccinated, helpStatus, credentials);

            return Result.Success(pet);
        }

    }
}
