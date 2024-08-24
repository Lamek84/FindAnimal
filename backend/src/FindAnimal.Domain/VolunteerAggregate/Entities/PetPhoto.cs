using CSharpFunctionalExtensions;
using FindAnimal.Domain.Shared;

namespace FindAnimal.Domain.VolunteerAggregate.Entities
{
    public class PetPhoto : Shared.Entity<PetPhotoId>
    {
        private PetPhoto(PetPhotoId id) : base(id) { }
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


        public static Result<PetPhoto> Create(PetPhotoId id, string title, string path, bool isMai)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.MAX_TITLE_NAME_LENGTH)
                return Result.Failure<PetPhoto>($"Invalid Title {nameof(title)} cannot be null or empty or longer than {Constants.MAX_TITLE_NAME_LENGTH} characters.");

            if (string.IsNullOrWhiteSpace(path) || path.Length > Constants.MAX_PATH_LENGTH)
                return Result.Failure<PetPhoto>($"Invalid Path {nameof(path)} cannot be null or empty or longer than {Constants.MAX_PATH_LENGTH} characters.");

            var pPhoto = new PetPhoto(id, title, path, isMai);

            return Result.Success(pPhoto);
        }
    }
}
