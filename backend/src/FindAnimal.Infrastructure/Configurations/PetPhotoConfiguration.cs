using FindAnimal.Domain.Shared;
using FindAnimal.Domain.VolunteerAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FindAnimal.Infrastructure.Configurations
{
    public class PetPhotoConfiguration : IEntityTypeConfiguration<PetPhoto>
    {
        public void Configure(EntityTypeBuilder<PetPhoto> builder)
        {
            builder.ToTable("tbl_petphotos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasConversion(
                    id => id.Value,
                    value => PetPhotoId.Create(value));

            builder.Property(p => p.Title).IsRequired().HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);

            builder.Property(p => p.Path).IsRequired().HasMaxLength(Constants.MAX_PATH_LENGTH);

            builder.Property(p => p.IsMain).IsRequired();
        }
    }
}
