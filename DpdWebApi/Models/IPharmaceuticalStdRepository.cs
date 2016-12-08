using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IPharmaceuticalStdRepository
    {
        IEnumerable<PharmaceuticalStd> GetAll();
        PharmaceuticalStd Get(int id);
    }
}
