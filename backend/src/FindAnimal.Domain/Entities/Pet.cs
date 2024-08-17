using FindAnimal.Domain.Entities.ValueObjects;
using FindAnimal.Domain.Enums;
using FindAnimal.Domain.Shared;
using System.Net;

namespace FindAnimal.Domain.Entities
{
    public class Pet : Entity<PetId>
    {
        private Pet(PetId id) :base(id)
        {
        }

        private Pet(PetId petId, string name, SpeciesId speciesId, string description, string breedName, string color, string healthInfo, Address address,
        double height, double weight, string phoneNumber, DateTimeOffset birthDate, bool isCastrated, bool isVaccinated, HelpStatus helpStatus, List<PetPhoto> photos, List<Credentials> credentials) : base(petId)
        {
        }

        public string Name { get; private set; } = string.Empty;
        public SpeciesId SpeciesId { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public string Breed { get; private set; } = string.Empty; 
        public string Color { get; private set; } = string.Empty;
        public string HelthInformation { get; private set; } = string.Empty;
        public Address LocationAddress { get; private set; }
        public double Height { get; private set; }
        public double Weigth { get; private set; }
        public string ContactNumber { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public bool IsCastrated { get; private set; }
        public bool IsVaccinated { get; private set; }
        public HelpStatus HelpStatus { get; private set; }
        public List<PetPhoto> Photos { get; private set; } = [];
        public List<Credentials> Credentials { get; private set; } = [];

    }
}
