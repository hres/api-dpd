using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class DrugProductSearchRepositorybk : IDrugProductSearchRepositorybk
    {
        private List<DrugProductSearchbk> drugs = new List<DrugProductSearchbk>();
        private DrugProductSearchbk drug = new DrugProductSearchbk();
        DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<DrugProductSearchbk> GetAllByCriteria(string din = "", string brandname = "", string company = "", string lang = "")
        {
            drugs = null; // dbConnection.GetBySearchCriteria(din, brandname, company, lang);

            return drugs;
        }

        public IEnumerable<DrugProductSearchbk> GetAll(string lang = "")
        {
            drugs = null; // dbConnection.GetAllDrugProduct(lang);

            return drugs;
        }

        public DrugProductSearchbk Get(int id, string lang)
        {
            drug = null; // dbConnection.GetDrugProductById(id, lang);
            return drug;
        }

    }

}