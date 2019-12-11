using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
    public interface IDataService
    {
        Task<IEnumerable<Vacancy>> GetVacanciesAsync();
    }
}