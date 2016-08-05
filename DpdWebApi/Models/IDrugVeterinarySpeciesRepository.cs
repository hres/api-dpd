using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IDrugVeterinarySpeciesRepository
    {
        IEnumerable<DrugVeterinarySpecies> GetAll(string lang);
        DrugVeterinarySpecies Get(int id, string lang);
    }
}
