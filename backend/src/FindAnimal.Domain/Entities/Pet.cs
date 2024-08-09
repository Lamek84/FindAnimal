using FindAnimal.Domain.Enums;

namespace FindAnimal.Domain.Entities
{
    public class Pet
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public AnimalType Type { get; private set; }
        public string Description { get; private set; }
        public string Breed { get; private set; }
        public string Color { get; private set; }
        public string HelthInformation { get; private set; }
        public string LocationAddress { get; private set; }
        public double Height { get; private set; }
        public double Weigth { get; private set; }
        public string ContactNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool IsCastrated { get; private set; }
        public bool IsVaccinated { get; private set; }
        public HelpStatus HelpStatus { get; private set; }
        public List<PetPhoto> Photos { get; private set; }
        public List<Credentials> Credentials { get; private set; }
        public DateTime? creationDate { get; private set; }

    }
}
