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


        public IEnumerable<TherapeuticClass> GetActiveIngredientByID(int id, string lang)
        {
            IEnumerable<TherapeuticClass> therapeuticClassList = databasePlaceholder.Get(id, lang);
            if (therapeuticClassList.Count()==0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return therapeuticClassList;
        }
    }
}