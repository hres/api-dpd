using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class PackagingController : ApiController
    {
        static readonly IPackagingRepository databasePlaceholder = new PackagingRepository();

        public IEnumerable<Packaging> GetAllActiveIngredient(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Packaging GetActiveIngredientByID(int id, string lang)
        {
            Packaging packaging = databasePlaceholder.Get(id, lang);
            if (packaging == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return packaging;
        }
    }
}