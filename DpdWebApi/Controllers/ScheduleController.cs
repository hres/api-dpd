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

        public IEnumerable<Schedule> GetAllActiveIngredient(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Schedule GetActiveIngredientByID(int id, string lang)
        {
            Schedule schedule = databasePlaceholder.Get(id, lang);
            if (schedule == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return schedule;
        }
    }
}