using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class RouteRepository : IRouteRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
    // most likely be a database of some sort, with an auto-incrementing ID field:
    private List<Route> _routes = new List<Route>();
    private Route _route = new Route();
    DBConnection dbConnection = new DBConnection("en");
    

    public IEnumerable<Route> GetAll()
    {
        _routes = dbConnection.GetAllRoute();

        return _routes;
    }


    public Route Get(int id)
    {
        _route = dbConnection.GetRouteByDrugCode(id);
        return _route;
    }


    }
}