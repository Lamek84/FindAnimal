using FindAnimal.Domain.Enums;

namespace FindAnimal.Domain.Entities
{
    public class Pet : Entity
    {
        public Pet() { }
        
        public string Name { get; private set; } = string.Empty;
        public AnimalType Type { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public string Breed { get; private set; } = string.Empty; 
        public string Color { get; private set; } = string.Empty;
        public string HelthInformation { get; private set; } = string.Empty;
        public string LocationAddress { get; private set; } = string.Empty;
        public double Height { get; private set; }
        public double Weigth { get; private set; }
        public string ContactNumber { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public bool IsCastrated { get; private set; }
        public bool IsVaccinated { get; private set; }
        public HelpStatus HelpStatus { get; private set; }
        public List<PetPhoto> Photos { get; private set; } = [];
        public List<Credentials> Credentials { get; private set; } = [];
        public DateTime? creationDate { get; private set; }

    }
}
