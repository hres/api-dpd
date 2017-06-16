using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class DrugProductRepository : IDrugProductRepository
    {
        private List<DrugProduct> drugs = new List<DrugProduct>();
        private DrugProduct drug = new DrugProduct();
        DBConnection dbConnection = new DBConnection("en");

        //KEEP if we decide to do the Search by Drug - Diane 2017-06-08
        //public IEnumerable<DrugProduct> GetAllByCriteria(string din = "", string brandname = "", string company = "", string lang = "")
        //{
        //    drugs = dbConnection.GetBySearchCriteria(din, brandname, company, lang);

        //    return drugs;
        //}

        public IEnumerable<DrugProduct> GetAll(string lang = "", string status = "")
        {
            drugs = dbConnection.GetAllDrugProduct(lang, status);

            return drugs;
        }

        public DrugProduct Get(int id, string lang, string status = "")
        {
            drug = dbConnection.GetDrugProductById(id, lang, status);
            return drug;
        }

    }

}