using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface ITherapeuticClassRepository
    {
        IEnumerable<TherapeuticClass> GetAll(string lang);
        TherapeuticClass Get(int id, string lang);
    }
}
