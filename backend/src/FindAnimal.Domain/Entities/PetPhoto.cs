
using FindAnimal.Domain.Shared;

namespace FindAnimal.Domain.Entities
{
    public class PetPhoto : Entity<PetPhotoId>
    {
        private PetPhoto(PetPhotoId id) :base(id) { }
        private PetPhoto(PetPhotoId id, string title, string path, bool isMain)
        : base(id)
        {
            Title = title;
            Path = path;
            IsMain = isMain;
        }
        public string Title { get; private set; }
        public string Path { get; private set; }
        public bool IsMain { get; private set; }
    }
}
