using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class FormRepository : IFormRepository
    {
        private List<Form> forms = new List<Form>();
        private Form form = new Form();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Form> GetAll(string lang)
        {
            forms = dbConnection.GetAllForm(lang);
            return forms;
        }

        public Form Get(int id, string lang)
        {
            form = dbConnection.GetFormByDrugCode(id, lang);
            return form;
        }
    }
}