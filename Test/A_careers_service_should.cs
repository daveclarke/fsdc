using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class A_careers_repo_should
    {
        private ILogger<DataService> _logger;
        private DataService _dataService;
        
        [TestInitialize]
        public void Initialise()
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger<DataService>();
            var dbContext = new CareersDbContext();
            dbContext.Database.Migrate();
            _dataService = new DataService(dbContext, _logger);
        }

        [TestMethod]
        public async Task return_a_list_of_careers()
        {
            // arrange
            
            // act
            var careers = await _dataService.GetVacanciesAsync().ConfigureAwait(false);

            // assert
            Assert.IsTrue(careers.Any());
        }

        [TestMethod]
        public async Task return_a_vacancy_by_id()
        {
            // arrange
            var firstVacancy = (await _dataService.GetVacanciesAsync().ConfigureAwait(false)).FirstOrDefault();

            // act
            var vacancy = await _dataService.GetVacancyByIdAsync(firstVacancy.Id).ConfigureAwait(false);

            // assert
            Assert.IsNotNull(vacancy);
            Assert.IsTrue(firstVacancy.Id.Equals( vacancy.Id));
        }
    }
}
