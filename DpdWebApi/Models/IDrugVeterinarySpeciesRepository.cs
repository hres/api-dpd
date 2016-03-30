using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IDrugVeterinarySpeciesRepository
    {
        IEnumerable<DrugVeterinarySpecies> GetAll();
        DrugVeterinarySpecies Get(int id);
    }
}
