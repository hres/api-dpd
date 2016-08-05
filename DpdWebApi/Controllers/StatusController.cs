using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;
namespace DpdWebApi.Controllers
{
    public class StatusController : ApiController
    {
        static readonly IStatusRepository databasePlaceholder = new StatusRepository();

        public IEnumerable<Status> GetAllStatus(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Status GetStatusByID(int id, string lang)
        {
            Status status = databasePlaceholder.Get(id, lang);
            if (status == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return status;
        }
    }
}
