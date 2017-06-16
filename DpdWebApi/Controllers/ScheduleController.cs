using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class ScheduleController : ApiController
    {
        static readonly IScheduleRepository databasePlaceholder = new ScheduleRepository();

        public IEnumerable<Schedule> GetAllSchedule(string lang, string active = "")
        {

            return databasePlaceholder.GetAll(lang, active);
        }


        public Schedule GetScheduleByDrugCode(int id, string lang, string active = "")
        {
            Schedule schedule = databasePlaceholder.Get(id, lang, active);
            if (schedule == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return schedule;
        }
    }
}