﻿using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class DrugProductController : ApiController
    {
        static readonly IDrugProductRepository databasePlaceholder = new DrugProductRepository();
       //KEEP if we decide to do the Search by Drug - Diane 2017-06-08
        //public IEnumerable<DrugProduct> GetBySearchCriteria(string din, string brandname, string company, string lang)
        //{
        //    return databasePlaceholder.GetAllByCriteria(din, brandname, company, lang);
        //}

        public DrugProduct GetDrugProductByID(int id, string lang = "", string status = "")
        {
            DrugProduct drugProduct = databasePlaceholder.Get(id, lang, status);
            if (drugProduct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return drugProduct;
        }

        public IEnumerable<DrugProduct> GetAllDrugProduct(string lang = "", string status = "", string brandname = "", string din = "")
        {

            return databasePlaceholder.GetAll(lang, status, brandname, din);
        }

        //public DrugProduct GetDrugProductByDin(string din, string lang = "", string status = "")
        //{
        //    DrugProduct drugProduct = databasePlaceholder.GetByDin(din, lang, status);
        //    if (drugProduct == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return drugProduct;
        //}
    }
}
