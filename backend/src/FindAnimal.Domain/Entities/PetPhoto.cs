
namespace FindAnimal.Domain.Entities
{
    public class PetPhoto : Entity
    {
        public string Title { get; private set; } = string.Empty;
        public string Path { get; private set; } = string.Empty;
        public bool IsMain { get; private set; }
    }
}
