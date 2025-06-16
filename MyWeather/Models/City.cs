using System.ComponentModel.DataAnnotations;

namespace MyWeather.Models
{
    public class City
    {

        public float Id { get; set; }
        public required string Name { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
        public required Coord Coord { get; set; }
    }

}
