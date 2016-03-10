using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class PharmaceuticalStdController : ApiController
    {
        static readonly IPharmaceuticalStdRepository databasePlaceholder = new PharmaceuticalStdRepository();

        public IEnumerable<PharmaceuticalStd> GetAllActiveIngredient()
        {

            return databasePlaceholder.GetAll();
        }


        public PharmaceuticalStd GetActiveIngredientByID(int id)
        {
            PharmaceuticalStd pharmaceuticalStd = databasePlaceholder.Get(id);
            if (pharmaceuticalStd == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return pharmaceuticalStd;
        }
    }
}