using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class SearchDrugController : ApiController
    {
        static readonly ISearchDrugRepository databasePlaceholder = new SearchDrugRepository();
        //to make them optional we must pass empty string
        //public IEnumerable<SearchDrug> GetBySearchCriteria(string din = "", string brandname = "", string company= "", string lang = "")
        //{
        //    return databasePlaceholder.GetAllByCriteria(din, brandname, company, lang);
        //}
        public IEnumerable<SearchDrug> GetBySearchCriteria(string din, string brandname, string company, string lang)
        {
            return databasePlaceholder.GetAllByCriteria(din, brandname, company, lang);
        }

        public SearchDrug GetSearchDrugProductByID(int id, string lang)
        {
            SearchDrug drugProduct = databasePlaceholder.Get(id, lang);
            if (drugProduct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return drugProduct;
        }

        public IEnumerable<SearchDrug> GetAllDrugProduct(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }
    }
}
