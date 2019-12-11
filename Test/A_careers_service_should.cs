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
        [TestMethod]
        public async Task return_a_list_of_careers()
        {
            // arrange
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<DataService>();
            using var dbContext = new CareersDbContext();
            dbContext.Database.Migrate();
            var dataService = new DataService(dbContext, logger);
            
            // act
            var careers = await dataService.GetVacanciesAsync().ConfigureAwait(false);

            // assert
            Assert.IsTrue(careers.Any());
        }
    }
}
