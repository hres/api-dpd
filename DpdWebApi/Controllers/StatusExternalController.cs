using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;
namespace DpdWebApi.Controllers
{
    public class StatusExternalController : ApiController
    {
        static readonly IStatusExternalRepository databasePlaceholder = new StatusExternalRepository();

        public IEnumerable<StatusExternal> GetAllStatusExternal(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public StatusExternal GetStatusExternalByID(int id, string lang)
        {
            StatusExternal statusExternal = databasePlaceholder.Get(id, lang);
            if (statusExternal == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return statusExternal;
        }
    }
}
