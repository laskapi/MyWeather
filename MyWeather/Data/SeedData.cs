using Microsoft.EntityFrameworkCore;
using MyWeather.Models;
using System.Text.Json;

namespace MyWeather.Data
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CitiesDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CitiesDbContext>>()))
            {
                if (context.Cities.Any())
                {
                   return;
                }

                var fileName = "city.list.json";
                var citiesJsonString = File.ReadAllText(fileName);


                var options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;

                List<City> cities = JsonSerializer.Deserialize<List<City>>(citiesJsonString, options) ?? [];


                Console.WriteLine("Initialisation finished. full cities count: " + cities.Count);
                List<City> polskie = [.. cities.Where(city => city.Country == "PL")];
                Console.WriteLine("Polish cities count: " + polskie.Count);

           
                context.AddRangeAsync(polskie);
                context.SaveChanges();
            }
        }
    }
}
