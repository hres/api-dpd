using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DpdWebApi.Models;

namespace DpdWebApi.Controllers
{
    public class DrugProductController : ApiController
    {
        static readonly IDrugProductRepository databasePlaceholder = new DrugProductRepository();

        public IEnumerable<DrugProduct> GetAllDrugProduct()
        {

            return databasePlaceholder.GetAll();
        }


        public DrugProduct GetDrugProductByID(int id)
        {
            DrugProduct drugProduct = databasePlaceholder.Get(id);
            if (drugProduct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return drugProduct;
        }

        public DrugProduct GetDrugProductByDin(string din)
        {
            DrugProduct drugProduct = databasePlaceholder.Get(din);
            if (drugProduct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return drugProduct;
        }
        //public HttpResponseMessage PostDrugProduct(DrugProduct drugProduct)
        //{
        //    drugProduct = databasePlaceholder.Add(drugProduct);
        //    string apiName = App_Start.WebApiConfig.DEFAULT_ROUTE_NAME;
        //    var response =
        //        this.Request.CreateResponse<DrugProduct>(HttpStatusCode.Created, drugProduct);
        //    string uri = Url.Link(apiName, new { id = drugProduct.DrugCode });
        //    response.Headers.Location = new Uri(uri);
        //    return response;
        //}


        //public bool PutPerson(DrugProduct drugProduct)
        //{
        //    if (!databasePlaceholder.Update(drugProduct))
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    return true;
        //}


        //public void DeleteDrugProduct(int id)
        //{
        //    DrugProduct drugProduct = databasePlaceholder.Get(id);
        //    if (drugProduct == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    databasePlaceholder.Remove(id);
        //}
    }
}
