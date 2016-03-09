using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class ScheduleRepository : IScheduleRepository
    {
        private List<Schedule> _schedules = new List<Schedule>();
        private Schedule _schedule = new Schedule();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Schedule> GetAll()
        {
            _schedules = dbConnection.GetAllSchedule();
            return _schedules;
        }

        public Schedule Get(int id)
        {
            _schedule = dbConnection.GetScheduleByDrugCode(id);
            return _schedule;
        }
    }
}