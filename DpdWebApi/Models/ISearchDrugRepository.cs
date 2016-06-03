using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface ISearchDrugRepository
    {
        IEnumerable<SearchDrug> GetAll(string lang, string din, string brandname, string company);
        SearchDrug Get(int id, string lang);
       // SearchDrug Get(string din, string lang);
    }
}
