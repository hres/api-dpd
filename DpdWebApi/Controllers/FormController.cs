using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class FormController : ApiController
    {
        static readonly IFormRepository databasePlaceholder = new FormRepository();

        public IEnumerable<Form> GetAllForm(string lang="", string active = "")
        {

            return databasePlaceholder.GetAll(lang, active);
        }


        public IEnumerable<Form>  GetFormByID(int id, string lang="", string active = "")
        {
            //Form form = databasePlaceholder.Get(id, lang, active);
            IEnumerable <Form> formList= databasePlaceholder.Get(id, lang, active);
            if (formList.Count()==0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return formList;
        }
    }
}