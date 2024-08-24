using FindAnimal.Domain.Shared;
using FindAnimal.Domain.SpeciesAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindAnimal.Infrastructure.Configurations
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable("tbl_breeds");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasConversion(
                    id => id.Value,
                    value => BreedId.Create(value))
                .HasColumnName("breed_id");

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(Constants.MAX_TITLE_NAME_LENGTH);
        }
    }
}
