using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DpdWebApi.Models;
namespace DpdWebApi.Controllers
{
    public class RouteController : ApiController
    {
        static readonly IRouteRepository databasePlaceholder = new RouteRepository();

        public IEnumerable<Route> GetAllRoute(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Route GetRouteByID(int id, string lang)
        {
            Route route = databasePlaceholder.Get(id, lang);
            if (route == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return route;
        }
    }
}
