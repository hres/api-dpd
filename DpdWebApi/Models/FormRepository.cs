using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class FormRepository : IFormRepository
    {
        private List<Form> forms = new List<Form>();
        private Form form = new Form();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Form> GetAll(string lang="", string active = "")
        {
            forms = dbConnection.GetAllForm(lang, active);
            return forms;
        }

        public IEnumerable<Form> Get(int id, string lang="", string active = "")
        {
            forms = dbConnection.GetFormByDrugCode(id, lang, active);
            return forms;
        }
    }
}