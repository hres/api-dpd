using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class DrugVeterinarySpeciesController : ApiController
    {
        static readonly IDrugVeterinarySpeciesRepository databasePlaceholder = new DrugVeterinarySpeciesRepository();

        public IEnumerable<DrugVeterinarySpecies> GetAllActiveIngredient(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public DrugVeterinarySpecies GetActiveIngredientByID(int id, string lang)
        {
            DrugVeterinarySpecies veterinarySpecies = databasePlaceholder.Get(id, lang);
            if (veterinarySpecies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return veterinarySpecies;
        }
    }
}