using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class ScheduleRepository : IScheduleRepository
    {
        private List<Schedule> schedules = new List<Schedule>();
        private Schedule schedule = new Schedule();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Schedule> GetAll(string lang = "", string active = "")
        {
            schedules = dbConnection.GetAllSchedule(lang, active);
            return schedules;
        }

        public IEnumerable<Schedule> Get(int id, string lang = "", string active = "")
        {
            schedules = dbConnection.GetScheduleByDrugCode(id, lang, active);
            return schedules;
        }
    }
}