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

        public IEnumerable<DrugVeterinarySpecies> GetAllActiveIngredient()
        {

            return databasePlaceholder.GetAll();
        }


        public DrugVeterinarySpecies GetActiveIngredientByID(int id)
        {
            DrugVeterinarySpecies veterinarySpecies = databasePlaceholder.Get(id);
            if (veterinarySpecies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return veterinarySpecies;
        }
    }
}