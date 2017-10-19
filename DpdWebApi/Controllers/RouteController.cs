using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using DpdWebApi.Models;
namespace DpdWebApi.Controllers
{
    public class RouteController : ApiController
    {
        static readonly IRouteRepository databasePlaceholder = new RouteRepository();

        public IEnumerable<Route> GetAllRoute(string lang = "", string active = "")
        {

            return databasePlaceholder.GetAll(lang, active);
        }


        public IEnumerable<Route> GetRouteByID(int id, string lang = "", string active = "")
        {
            //Route route = databasePlaceholder.Get(id, lang, active);
            IEnumerable<Route> routeList = databasePlaceholder.Get(id, lang, active);
            if (routeList.Count()==0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return routeList;
        }
    }
}
