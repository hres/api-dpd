using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;
namespace DpdWebApi.Controllers
{
    public class CompanyController : ApiController
    {
        static readonly ICompanyRepository databasePlaceholder = new CompanyRepository();

        public IEnumerable<Company> GetAllCompany(string lang="")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Company GetCompanyByID(int id, string lang="")
        {
            Company company = databasePlaceholder.Get(id, lang);
            if (company == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return company;
        }
    }
}
