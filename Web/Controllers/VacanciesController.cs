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
    public class VacanciesController : Controller
    {
        private readonly ILogger<VacanciesController> _logger;
        private readonly IDataService _dataService;
        private readonly IHttpClientFactory _clientFactory;

        public VacanciesController(ILogger<VacanciesController> logger, IDataService dataService, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _dataService = dataService;
            _clientFactory = clientFactory;
        }

        [HttpGet("/vacancies")]
        public async Task<IActionResult> Get()
        {
            var vacancies = await _dataService.GetVacanciesAsync();
            var locationClient = _clientFactory.CreateClient(Startup.LOCATION_CLIENT);
            var locationResponse = await locationClient.GetAsync("location");
            if (!locationResponse.IsSuccessStatusCode) return NotFound();

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var locations = await JsonSerializer.DeserializeAsync<List<LocationModel>>(await locationResponse.Content.ReadAsStreamAsync(), options);

            var vacancyLocation = vacancies.Join(locations, v => v.LocationId, l => l.Id, (v, l) => new VacancyLocationModel
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                LocationId = l.Id,
                LocationName = l.Name,
                LocationState = l.State,
                PostedDate = v.PostedDate,
            });
            
            return new JsonResult(vacancyLocation);
        }

    }
}
