using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class SearchDrugRepository : ISearchDrugRepository
    {
        private List<SearchDrug> _drugs = new List<SearchDrug>();
        private SearchDrug _drug = new SearchDrug();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<SearchDrug> GetAllByCriteria(string din = "", string brandname = "", string company = "", string lang = "")
        {
            _drugs = dbConnection.GetBySearchCriteria(din, brandname, company, lang);

            return _drugs;
        }

        public IEnumerable<SearchDrug> GetAll(string lang = "")
        {
            _drugs = dbConnection.GetAllDrugProduct(lang);

            return _drugs;
        }

        public SearchDrug Get(int id, string lang)
        {
            _drug = dbConnection.GetSearchDrugProductById(id, lang);
            return _drug;
        }

    }

}