using MyWeather.Models;

namespace MyWeather.Data
{
    public interface ICityRepository
    {
        public Task<Dictionary<float,string>> getAll();
        public Task<City> getById(float id);
    }
}
