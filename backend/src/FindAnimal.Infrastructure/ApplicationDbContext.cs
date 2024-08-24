using FindAnimal.Domain.SpeciesAggregate.Entities;
using FindAnimal.Domain.VolunteerAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FindAnimal.Infrastructure
{
    public class ApplicationDbContext(IConfiguration configuration) : DbContext
    {
        /*с помощью праймери конструктора на ненадо писать ниже код, а задать как параметр в классе */
        //private readonly IConfiguration _configuration;
        //public ApplicationDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        private const string DATABASE = "Database";

        public DbSet<Volunteer> Volunteers => Set<Volunteer>();
        public DbSet<Species> Species => Set<Species>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(DATABASE));
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        private ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => {builder.AddConsole();});   
    }
}
