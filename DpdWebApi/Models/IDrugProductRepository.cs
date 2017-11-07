using System.Collections.Generic;

namespace DpdWebApi.Models
{
    interface IDrugProductRepository
    {
        //KEEP if we decide to do the Search by Drug - Diane 2017-06-08
        //IEnumerable<DrugProduct> GetAllByCriteria(string din = "", string brandname = "", string company = "", string lang = "");
        IEnumerable<DrugProduct> GetAll(string lang = "", string status = "", string brandname = "", string din = "");
        DrugProduct Get(int id, string lang = "", string status = "");
        //DrugProduct GetByDin(string din, string lang = "", string status = "");
    }
}
