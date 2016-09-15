using System.Collections.Generic;

namespace DpdWebApi.Models
{
    interface IDrugProductRepository
    {
        IEnumerable<DrugProduct> GetAllByCriteria(string din = "", string brandname = "", string company = "", string lang = "");
        IEnumerable<DrugProduct> GetAll(string lang = "");
        DrugProduct Get(int id, string lang);
    }
}
