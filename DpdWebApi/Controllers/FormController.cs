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

        public IEnumerable<Form> GetAllForm(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public Form GetFormByID(int id, string lang)
        {
            Form form = databasePlaceholder.Get(id, lang);
            if (form == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return form;
        }
    }
}