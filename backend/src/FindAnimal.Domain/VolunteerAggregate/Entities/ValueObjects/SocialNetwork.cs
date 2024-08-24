using CSharpFunctionalExtensions;


namespace FindAnimal.Domain.VolunteerAggregate.Entities.ValueObjects
{
    public record SocialNetwork
    {
        private SocialNetwork() { }
        private SocialNetwork(string title, string link)
        {
            Title = title;
            Link = link;
        }


        public string Title { get; }
        public string Link { get; }


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
