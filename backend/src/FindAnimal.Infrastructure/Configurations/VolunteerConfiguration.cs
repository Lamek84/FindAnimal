using FindAnimal.Domain.Shared;
using FindAnimal.Domain.VolunteerAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FindAnimal.Infrastructure.Configurations
{
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable("tbl_volunteers");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Id)
                .HasConversion(
                    id => id.Value, 
                    value =>VolunteerId.Create(value));

            builder.ComplexProperty(v => v.PersonFullName, nm =>
            {
                nm.Property(v => v.FirstName)
                    .IsRequired().HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);

                nm.Property(v => v.LastName)
                    .IsRequired().HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);

                nm.Property(v => v.Patronymic)
                    .IsRequired().HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);
            });

            builder.Property(v => v.Description)
                .IsRequired().HasMaxLength(Constants.MIDDLE_TEXT_LENGTH);

            builder.Property(v => v.YearsOfExperience).IsRequired();

            builder.ComplexProperty(v => v.Phone, vb =>
                {
                    vb.Property(p => p.Value).IsRequired().HasMaxLength(Constants.MAX_PHONE_NUMBER_LENGTH); ;
                });

            builder.OwnsOne(v => v.SocialNetworks, sb =>
            {
                sb.ToJson();
                sb.OwnsMany(v => v.NetworksList, soc =>
                {
                    soc.Property(v => v.Title)
                        .IsRequired().HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);

                    soc.Property(v => v.Link)
                        .IsRequired().HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);
                });
            });

            builder.OwnsOne(v => v.Credentials, cb =>
            {
                cb.OwnsMany(v => v.CredentialsList, cr =>
                {
                    cr.Property(v => v.Title)
                        .IsRequired().HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);

                    cr.Property(v => v.Description)
                        .IsRequired().HasMaxLength(Constants.MIDDLE_TEXT_LENGTH);
                });
            });

            builder.HasMany(v => v.Pets)
                .WithOne()
                .HasForeignKey("volunteer_Id")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
