using System;

namespace Web.Models
{
    public class VacancyLocationModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationState { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}