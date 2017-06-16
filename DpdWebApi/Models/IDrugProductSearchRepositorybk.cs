using System.Collections.Generic;

namespace DpdWebApi.Models
{
    interface IDrugProductSearchRepositorybk
    {
        IEnumerable<DrugProductSearchbk> GetAllByCriteria(string din = "", string brandname = "", string company = "", string lang = "");
        IEnumerable<DrugProductSearchbk> GetAll(string lang = "");
        DrugProductSearchbk Get(int id, string lang);
    }
}
