using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class SearchDrugController : ApiController
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
