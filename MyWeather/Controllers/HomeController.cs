using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWeather.Data;
using MyWeather.Models;
using MyWeather.Services;

namespace MyWeather.Controllers
{
    public class CityId
    {
        public required float id { get; set; }
    }


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICityRepository _cityRepository;
        private readonly HttpWeatherService _httpWeatherService;

        public HomeController(ILogger<HomeController> logger, ICityRepository cityRepository,
            HttpWeatherService httpWeatherService)
        {
            _logger = logger;
            _cityRepository = cityRepository;
            _httpWeatherService = httpWeatherService;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _cityRepository.getAll();
            // _logger.LogInformation(string.Join(",",cities));
            var selectList = new SelectList(cities, "Key", "Value");
            var selectedCity = selectList.Where(c => c.Text == "Warszawa").First();
            selectedCity.Selected = true;
            ViewBag.cities = selectList;

            var city = await _cityRepository.getById(float.Parse(selectedCity.Value));
            Report report = new Report(await _httpWeatherService.GetReportAsync(city.Coord.lat, city.Coord.lon) ?? new WeatherApiResponse());
            return View(report);
        }


        [HttpPost]
        public async Task<ActionResult<Report?>> GetReport([FromBody] CityId cityId)
        {

            var city = await _cityRepository.getById(cityId.id);
            Report report = new Report(await _httpWeatherService.GetReportAsync(city.Coord.lat, city.Coord.lon) ?? new WeatherApiResponse());
            return report;
        }




        //---------------
        //---------------unused because of the flickering on icon upload
        [HttpPost]
        public async Task<IActionResult> _WeatherPartial([FromBody] CityId cityId)
        {

            var city = await _cityRepository.getById(cityId.id);

            Report report = new Report(await _httpWeatherService.GetReportAsync(city.Coord.lat, city.Coord.lon) ?? new WeatherApiResponse());

            // _logger.LogWarning("Report: " + report?.name?.ToString() + " :: " + report?.weather?[0].description);

            return PartialView(report);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
