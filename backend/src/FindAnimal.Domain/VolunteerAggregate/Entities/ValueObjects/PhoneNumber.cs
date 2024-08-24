using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;


namespace FindAnimal.Domain.VolunteerAggregate.Entities.ValueObjects
{
    public record PhoneNumber
    {
        private PhoneNumber() { }
        private PhoneNumber(string number) => Value = number;


        private const string PhoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\-]?)?[\d\-]{7,10}$";
        public string Value { get; }

        public static Result<PhoneNumber> Create(string number)
        {
            if (string.IsNullOrWhiteSpace(number?.Trim()))
                return Result.Failure<PhoneNumber>($"Invalid Phone Number");

            number = number.Trim();

            if (Regex.IsMatch(number, PhoneRegex) == false)
                return Result.Failure<PhoneNumber>($"Invalid Phone Number");

            return new PhoneNumber(number);
        }
    }
}
