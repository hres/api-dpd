using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface oldIDrugProductRepository
    {
        IEnumerable<oldDrugProductbk> GetAll(string lang);
        oldDrugProductbk Get(int id, string lang);
        oldDrugProductbk Get(string din, string lang);
        // DrugProduct Add(DrugProduct drugProduct);
        // void Remove(int id);
        // bool Update(DrugProduct drugProduct);
    }
}
