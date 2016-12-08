using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DpdWebApi.Models;
namespace DpdWebApi.Controllers
{
    public class PharmaceuticalStdController : ApiController
    {
        static readonly IPharmaceuticalStdRepository databasePlaceholder = new PharmaceuticalStdRepository();

        public IEnumerable<PharmaceuticalStd> GetAllPharmaceuticalStd()
        {

            return databasePlaceholder.GetAll();
        }


        public PharmaceuticalStd GetPharmaceuticalStdByID(int id)
        {
            PharmaceuticalStd pharmaceuticalstd = databasePlaceholder.Get(id);
            if (pharmaceuticalstd == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return pharmaceuticalstd;
        }
    }
}
