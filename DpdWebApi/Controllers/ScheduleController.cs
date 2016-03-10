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

        public IEnumerable<Schedule> GetAllActiveIngredient()
        {

            return databasePlaceholder.GetAll();
        }


        public Schedule GetActiveIngredientByID(int id)
        {
            Schedule schedule = databasePlaceholder.Get(id);
            if (schedule == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return schedule;
        }
    }
}