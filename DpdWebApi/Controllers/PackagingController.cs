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

        public IEnumerable<Packaging> GetAllPackaging()
        {

            return databasePlaceholder.GetAll();
        }


        public Packaging GetPackagingByDrugCode(int id)
        {
            Packaging packaging = databasePlaceholder.Get(id);
            if (packaging == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return packaging;
        }
    }
}