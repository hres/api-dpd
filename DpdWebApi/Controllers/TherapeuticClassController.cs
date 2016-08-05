using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class TherapeuticClassController : ApiController
    {
        static readonly ITherapeuticClassRepository databasePlaceholder = new TherapeuticClassRepository();

        public IEnumerable<TherapeuticClass> GetAllActiveIngredient(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public TherapeuticClass GetActiveIngredientByID(int id, string lang)
        {
            TherapeuticClass therapeuticClass = databasePlaceholder.Get(id, lang);
            if (therapeuticClass == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return therapeuticClass;
        }
    }
}