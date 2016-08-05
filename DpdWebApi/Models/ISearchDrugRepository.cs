using System.Collections.Generic;

namespace DpdWebApi.Models
{
    interface ISearchDrugRepository
    {
        IEnumerable<SearchDrug> GetAllByCriteria(string din = "", string brandname = "", string company = "", string lang = "");
        IEnumerable<SearchDrug> GetAll(string lang = "");
        SearchDrug Get(int id, string lang);
    }
}
