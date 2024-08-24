using FindAnimal.Infrastructure;

namespace FindAnimal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ApplicationDbContext>();

            var app = builder.Build();

            app.Run();
        }
    }
}



