using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class RouteRepository : IRouteRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
    // most likely be a database of some sort, with an auto-incrementing ID field:
    private List<Route> routes = new List<Route>();
    private Route route = new Route();
    DBConnection dbConnection = new DBConnection("en");
    

    public IEnumerable<Route> GetAll(string lang)
    {
        routes = dbConnection.GetAllRoute(lang);

        return routes;
    }


    public Route Get(int id, string lang)
    {
        route = dbConnection.GetRouteByDrugCode(id, lang);
        return route;
    }


    }
}