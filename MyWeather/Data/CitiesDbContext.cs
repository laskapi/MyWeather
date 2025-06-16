using Microsoft.EntityFrameworkCore;
using MyWeather.Models;


namespace MyWeather.Data
{
    public class CitiesDbContext : DbContext
    {
        public CitiesDbContext(DbContextOptions<CitiesDbContext> options):base(options) {}

        public DbSet<City> Cities { get; set; } = default!;
    }
}
