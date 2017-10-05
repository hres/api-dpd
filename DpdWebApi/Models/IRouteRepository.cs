using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IRouteRepository
    {
        IEnumerable<Route> GetAll(string lang, string active = "");
        IEnumerable<Route> Get(int id, string lang, string active = "");
    }
}
