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

        public IEnumerable<Status> GetAllStatus()
        {

            return databasePlaceholder.GetAll();
        }


        public Status GetStatusByID(int id)
        {
            Status status = databasePlaceholder.Get(id);
            if (status == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return status;
        }
    }
}
