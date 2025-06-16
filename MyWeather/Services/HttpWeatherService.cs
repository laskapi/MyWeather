using MyWeather.Models;

namespace MyWeather.Services
{
    public class HttpWeatherService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public HttpWeatherService(IConfiguration configuration,HttpClient httpClient, ILogger<HttpWeatherService> logger)
        {
            _configuration= configuration;
            _httpClient = httpClient;
            _logger = logger;
            _httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
        }

        public async Task<WeatherApiResponse?> GetReportAsync(double latitude, double longitude)
        {

           var apiKey = _configuration["ApiKey"];

            /*      var response = await _httpClient.GetStringAsync($"weather?lat={latitude}&lon={longitude}&appid={apiKey}");
                  Console.WriteLine("Response from weather API: " + response);
                  return await Task.FromResult(new ResponseModel());

      */
            try
            {
                var response = await _httpClient.GetFromJsonAsync<WeatherApiResponse>($"weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric&lang=pl");
                return response;
            }

            catch(HttpRequestException ex)
            {
                _logger.LogError(ex,ex.Message);
                return null;
            }
            
        }

    }
}
