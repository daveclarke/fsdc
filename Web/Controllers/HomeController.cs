using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataService _dataService;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IDataService dataService, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _dataService = dataService;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var vacancies = await _dataService.GetVacanciesAsync();
            var locationClient = _clientFactory.CreateClient(Startup.LOCATION_CLIENT);
            var locationResponse = await locationClient.GetAsync("location");
            if (!locationResponse.IsSuccessStatusCode) return Error();

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var locations = await JsonSerializer.DeserializeAsync<LocationModel[]>(await locationResponse.Content.ReadAsStreamAsync(), options);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
