using CSharpFunctionalExtensions;


namespace FindAnimal.Domain.VolunteerAggregate.Entities.ValueObjects
{
    public record PersonFullName
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string? Patronymic { get; }


        private PersonFullName() { }
        private PersonFullName(string firtsName, string lastName, string? patronymic = null)
        {
            FirstName = firtsName;
            LastName = lastName;
            Patronymic = patronymic;
        }


        public static Result<PersonFullName> Create(string firstName, string lastName, string? patronymic = null)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result.Failure<PersonFullName>($"Invalid First Name! {nameof(firstName)} cannot be null and cannot contain special characters");
            if (string.IsNullOrWhiteSpace(lastName))
                return Result.Failure<PersonFullName>($"Invalid Last Name! {nameof(lastName)} cannot be null and cannot contain special characters");
            if (patronymic != null)
                return Result.Failure<PersonFullName>($"Invalid patronymic {nameof(patronymic)} cannot be null and cannot contain special characters");

            var fullName = new PersonFullName(firstName, lastName, patronymic);
            return Result.Success(fullName);
        }
    }
}
