using FindAnimal.Domain.Enums;
using FindAnimal.Domain.Shared;
using FindAnimal.Domain.SpeciesAggregate.Entities;
using FindAnimal.Domain.VolunteerAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FindAnimal.Infrastructure.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("tbl_pets");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                    id => id.Value,
                    value => PetId.Create(value));

            builder.Property(p => p.Name).IsRequired().HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);

            builder.ComplexProperty(p => p.AnimalType, at =>
            {
                at.IsRequired();
                at.Property(a => a.SpeciesId)
                    .HasConversion(
                        id => id.Value, 
                        value => SpeciesId.Create(value))
                    .HasColumnName("species_Id");
                at.Property(a => a.BreedId)
                    .HasConversion(
                        id => id.Value, 
                        value => BreedId.Create(value))
                    .HasColumnName("breed_Id");
            });
            
            builder.Property(p => p.Description).IsRequired().HasMaxLength(Constants.MIDDLE_TEXT_LENGTH);

            builder.Property(p => p.Color).IsRequired().HasMaxLength(Constants.MIN_TEXT_LENGTH);

            builder.Property(p => p.HelthInformation).IsRequired();

            builder.ComplexProperty(p => p.LocationAddress, lAb =>
            {
                lAb.Property(a => a.Street).IsRequired().HasMaxLength(Constants.MIN_TEXT_LENGTH);
                lAb.Property(a => a.HouseNumber).IsRequired();
                lAb.Property(a => a.City).IsRequired().HasMaxLength(Constants.MIN_TEXT_LENGTH);
                lAb.Property(a => a.State).IsRequired().HasMaxLength(Constants.MIN_TEXT_LENGTH);
                lAb.Property(a => a.ZipCode).IsRequired();
            });
                 
            builder.Property(p => p.Height).IsRequired();

            builder.Property(p => p.Weigth).IsRequired();

            builder.ComplexProperty(p => p.ContactNumber, cb =>
            {
                cb.Property(p => p.Value).IsRequired().HasMaxLength(Constants.MAX_PHONE_NUMBER_LENGTH);
            });

            builder.Property(p => p.BirthDate).IsRequired();

            builder.Property(p => p.IsCastrated).IsRequired();

            builder.Property(p => p.IsVaccinated).IsRequired();

            builder.Property(p => p.HelpStatus)
                .HasConversion(
                    status => status.ToString(),
                    value => (HelpStatus)Enum.Parse(typeof(HelpStatus), value));

            builder.OwnsOne(v => v.Credentials, cb =>
            {
                cb.ToJson();
                cb.OwnsMany(v => v.CredentialsList, cr =>
                {
                    cr.Property(v => v.Title).IsRequired().HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);
                    cr.Property(v => v.Description).IsRequired().HasMaxLength(Constants.MIDDLE_TEXT_LENGTH);
                });
            });

            builder.HasMany(v => v.Photos)
                .WithOne()
                .HasForeignKey("photos_Id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
