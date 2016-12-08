using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class ScheduleRepository : IScheduleRepository
    {
        private List<Schedule> schedules = new List<Schedule>();
        private Schedule schedule = new Schedule();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Schedule> GetAll(string lang)
        {
            schedules = dbConnection.GetAllSchedule(lang);
            return schedules;
        }

        public Schedule Get(int id, string lang)
        {
            schedule = dbConnection.GetScheduleByDrugCode(id, lang);
            return schedule;
        }
    }
}