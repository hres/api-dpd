using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IDrugProductRepository
    {
        IEnumerable<DrugProduct> GetAll(string lang);
        DrugProduct Get(int id, string lang);
        DrugProduct Get(string din, string lang);
        // DrugProduct Add(DrugProduct drugProduct);
        // void Remove(int id);
        // bool Update(DrugProduct drugProduct);
    }
}
