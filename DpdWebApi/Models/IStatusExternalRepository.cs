using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IStatusExternalRepository
    {
        IEnumerable<StatusExternal> GetAll(string lang);
        StatusExternal Get(int id, string lang);
    }
}
