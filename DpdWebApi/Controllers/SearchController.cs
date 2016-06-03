using DpdWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace DpdWebApi.Controllers
{
    public class SearchController : ApiController
    {
            static readonly ISearchDrugRepository databasePlaceholder = new SearchDrugRepository();

            public IEnumerable<SearchDrug> GetBySearchCriteria(string lang, string din, string brandname, string company)
            {
                return databasePlaceholder.GetAll(lang, din, brandname, company);
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
        }
}
