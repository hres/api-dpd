using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class SearchDrugRepository : ISearchDrugRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
        // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<SearchDrug> _drugs = new List<SearchDrug>();
        private SearchDrug _drug = new SearchDrug();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<SearchDrug> GetAll(string lang, string din, string brandname, string company)
        {
            _drugs = dbConnection.GetBySearchCriteria(lang, din, brandname, company);

            return _drugs;
        }

        public SearchDrug Get(int id, string lang)
        {
            _drug = dbConnection.GetSearchDrugProductById(id, lang);
            return _drug;
        }

    }

}