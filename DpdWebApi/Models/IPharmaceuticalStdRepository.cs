using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IPharmaceuticalStdRepository
    {
        IEnumerable<PharmaceuticalStd> GetAll(string lang);
        PharmaceuticalStd Get(int id, string lang);
    }
}
