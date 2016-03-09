using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IVeterinarySpeciesRepository
    {
        IEnumerable<VeterinarySpecies> GetAll();
        VeterinarySpecies Get(int id);
    }
}
