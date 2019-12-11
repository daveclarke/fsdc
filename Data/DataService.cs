using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Models;
using System;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class DataService : IDataService
    {
        private readonly CareersDbContext _dbContext;
        private readonly ILogger _logger;

        public DataService(CareersDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger; 
        }

        public async Task<IEnumerable<Vacancy>> GetVacanciesAsync()
        {
            var vacancies = new List<Vacancy>();
            try
            {
                vacancies = await _dbContext.Vacancies.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "### exception getting vacancies");
            }
            return vacancies;
        }
    }
}