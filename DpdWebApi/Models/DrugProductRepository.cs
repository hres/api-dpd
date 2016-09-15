using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class DrugProductRepository : IDrugProductRepository
    {
        private List<DrugProduct> _drugs = new List<DrugProduct>();
        private DrugProduct _drug = new DrugProduct();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<DrugProduct> GetAllByCriteria(string din = "", string brandname = "", string company = "", string lang = "")
        {
            _drugs = dbConnection.GetBySearchCriteria(din, brandname, company, lang);

            return _drugs;
        }

        public IEnumerable<DrugProduct> GetAll(string lang = "")
        {
            _drugs = dbConnection.GetAllDrugProduct(lang);

            return _drugs;
        }

        public DrugProduct Get(int id, string lang)
        {
            _drug = dbConnection.GetDrugProductById(id, lang);
            return _drug;
        }

    }

}