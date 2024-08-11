
namespace FindAnimal.Domain.Entities
{
    public class Volunteer : Entity
    {
        public Volunteer() { }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Description { get; private set; }
        public int YearsOfExperience { get; private set; }
        public int NumberOfPetFoundeHome { get; private set; }
        public int NumberOfPetLookingHome { get; private set; }
        public int NumberOfPetInTreatment { get; private set; }
        public string Phone { get; private set; }
        public List<SocialNetwork> SocialNetworks { get; private set; }
        public List<Credentials> Credentials { get; private set; }
        public List<Pet> Pets { get; private set; }
    }
}
