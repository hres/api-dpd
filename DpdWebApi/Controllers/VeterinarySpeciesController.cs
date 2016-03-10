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

        public IEnumerable<VeterinarySpecies> GetAllActiveIngredient()
        {

            return databasePlaceholder.GetAll();
        }


        public VeterinarySpecies GetActiveIngredientByID(int id)
        {
            VeterinarySpecies veterinarySpecies = databasePlaceholder.Get(id);
            if (veterinarySpecies == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return veterinarySpecies;
        }
    }
}