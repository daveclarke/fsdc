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
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            if (dataService == null) throw new ArgumentNullException(nameof(dataService));
            if (clientFactory == null) throw new ArgumentNullException(nameof(clientFactory));

            _logger = logger;
            _dataService = dataService;
            _clientFactory = clientFactory;
        }

        public IActionResult Index() => View();

        [HttpGet("/Home/{id:guid}")]
        public async Task<IActionResult> Detail(Guid id)
        {
            var vacancy = await _dataService.GetVacancyByIdAsync(id);
            var locationClient = _clientFactory.CreateClient(Startup.LOCATION_CLIENT);
            var locationResponse = await locationClient.GetAsync("location");
            LocationModel location = null;
            if (locationResponse.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var locations = await JsonSerializer.DeserializeAsync<List<LocationModel>>(await locationResponse.Content.ReadAsStreamAsync(), options);
                location = locations.FirstOrDefault(l => l.Id == vacancy.LocationId);
            }

            return View(new VacancyLocationModel
            {
                Id = vacancy.Id,
                Title = vacancy.Title,
                Description = vacancy.Description,
                LocationId = vacancy.LocationId,
                LocationName = location?.Name,
                LocationState = location?.State,
                PostedDate = vacancy.PostedDate,
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
