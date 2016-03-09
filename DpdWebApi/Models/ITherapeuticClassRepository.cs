using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface ITherapeuticClassRepository
    {
        IEnumerable<TherapeuticClass> GetAll();
        TherapeuticClass Get(int id);
    }
}
