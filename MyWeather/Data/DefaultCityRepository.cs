
using Microsoft.EntityFrameworkCore;
using MyWeather.Models;

namespace MyWeather.Data
{

    public class DefaultCityRepository(CitiesDbContext context)  : ICityRepository
    {
        private readonly CitiesDbContext _context = context;

        public async Task<Dictionary<float, string>> getAll() => await _context.Cities.OrderBy(c=>c.Name)
            .ToDictionaryAsync(c => c.Id, c => c.Name);

        public async Task<City> getById(float id) => await _context.Cities.Where(c=>c.Id==id)
            .Include(c=>c.Coord)
            .SingleAsync(c => c.Id == id);
         
            
        
            
        
    }
}
