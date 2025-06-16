namespace MyWeather.Models
{
    public class Report(WeatherApiResponse responseModel)
    {
        public string name { get;} = responseModel.name;
        public string description { get; } = responseModel.weather[0].description;
        public string icon { get;} = $"https://openweathermap.org/img/wn/{responseModel.weather[0].icon}@2x.png" ;
                               
        public float temp { get; } = responseModel.main.temp;
        public int humidity { get; } = responseModel.main.humidity;
        public float speed { get; } = responseModel.wind.speed;
        public int deg { get; }=responseModel.wind.deg;
      
    }
}
