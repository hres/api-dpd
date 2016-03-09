using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;
namespace DpdWebApi.Controllers
{
    public class RouteController : ApiController
    {
        static readonly IRouteRepository databasePlaceholder = new RouteRepository();

        public IEnumerable<Route> GetAllRoute()
        {

            return databasePlaceholder.GetAll();
        }


        public Route GetRouteByID(int id)
        {
            Route route = databasePlaceholder.Get(id);
            if (route == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return route;
        }
    }
}
