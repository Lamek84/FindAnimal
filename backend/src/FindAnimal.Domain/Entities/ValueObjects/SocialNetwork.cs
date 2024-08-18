using CSharpFunctionalExtensions;


namespace FindAnimal.Domain.Entities.ValueObjects
{
    public record SocialNetwork
    {
        public string Title { get; }
        public string Link { get; }

        public SocialNetwork() {}

        private SocialNetwork(string title, string link)
        {
            Title = title;
            Link = link;
        }

        public static Result<SocialNetwork> Create(string title, string link)
        {
            if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(link))
            {
                return Result.Failure<SocialNetwork>("Name or Link can't be empty or has a leer tab");
            }
            return new SocialNetwork(title, link);
        }
    }
}
