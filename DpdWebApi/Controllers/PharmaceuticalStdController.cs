using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DpdWebApi.Models;
namespace DpdWebApi.Controllers
{
    public class PharmaceuticalStdController : ApiController
    {
        static readonly IPharmaceuticalStdRepository databasePlaceholder = new PharmaceuticalStdRepository();

        public IEnumerable<PharmaceuticalStd> GetAllPharmaceuticalStd(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public PharmaceuticalStd GetPharmaceuticalStdByID(int id, string lang)
        {
            PharmaceuticalStd pharmaceuticalstd = databasePlaceholder.Get(id, lang);
            if (pharmaceuticalstd == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return pharmaceuticalstd;
        }
    }
}
