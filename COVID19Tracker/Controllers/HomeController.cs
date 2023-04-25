using COVID19Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;


namespace COVID19Tracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();

        }

        public async Task<ActionResult> Index()
        {
            var response = await _client.GetAsync("https://api.covid19api.com/summary");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult>(body);

            var covidData = result.Countries.Select(c => new CovidDataModel
            {
                Country = c.Country,
                TotalConfirmed = c.TotalConfirmed,
                TotalDeaths = c.TotalDeaths,
                TotalRecovered = c.TotalConfirmed - c.TotalDeaths,
                NewConfirmed = c.NewConfirmed,
                NewDeaths = c.NewDeaths,
                NewRecovered = c.NewConfirmed - c.NewDeaths
            }).ToList();

            return View(covidData);
        }
        public async Task<ActionResult> Data()
        {
            var response = await _client.GetAsync("https://api.covid19api.com/summary");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var body = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResult>(body);

            var covidData = result.Countries.Select(c => new CovidDataModel
            {
                Country = c.Country,
                TotalConfirmed = c.TotalConfirmed,
                TotalDeaths = c.TotalDeaths,
                TotalRecovered = c.TotalConfirmed - c.TotalDeaths,
                NewConfirmed = c.NewConfirmed,
                NewDeaths = c.NewDeaths,
                NewRecovered = c.NewConfirmed - c.NewDeaths
            }).ToList();

            return View(covidData);
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