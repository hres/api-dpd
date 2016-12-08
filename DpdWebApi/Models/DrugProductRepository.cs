using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class DrugProductRepository : IDrugProductRepository
    {
        private List<DrugProduct> drugs = new List<DrugProduct>();
        private DrugProduct drug = new DrugProduct();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<DrugProduct> GetAllByCriteria(string din = "", string brandname = "", string company = "", string lang = "")
        {
            drugs = dbConnection.GetBySearchCriteria(din, brandname, company, lang);

            return drugs;
        }

        public IEnumerable<DrugProduct> GetAll(string lang = "")
        {
            drugs = dbConnection.GetAllDrugProduct(lang);

            return drugs;
        }

        public DrugProduct Get(int id, string lang)
        {
            drug = dbConnection.GetDrugProductById(id, lang);
            return drug;
        }

    }

}