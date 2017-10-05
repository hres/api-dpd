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


        public IEnumerable<Schedule> GetScheduleByDrugCode(int id, string lang, string active = "")
        {
            //Schedule schedule = databasePlaceholder.Get(id, lang, active);
            IEnumerable<Schedule> scheduleList= databasePlaceholder.Get(id, lang, active);
            if (scheduleList.Count()==0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return scheduleList;
        }
    }
}