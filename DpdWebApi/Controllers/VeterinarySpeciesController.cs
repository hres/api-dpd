using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class VeterinarySpeciesController : ApiController
    {
        static readonly IVeterinarySpeciesRepository databasePlaceholder = new VeterinarySpeciesRepository();

        public IEnumerable<VeterinarySpecies> GetAllActiveIngredient(string lang="")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public IEnumerable<VeterinarySpecies> GetActiveIngredientByID(int id, string lang="")
        {
            IEnumerable<VeterinarySpecies> veterinarySpeciesList = databasePlaceholder.Get(id, lang);
            if (veterinarySpeciesList.Count()==0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return veterinarySpeciesList;
        }
    }
}