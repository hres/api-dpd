using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class FormRepository : IFormRepository
    {
        private List<Form> _forms = new List<Form>();
        private Form _form = new Form();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Form> GetAll(string lang)
        {
            _forms = dbConnection.GetAllForm(lang);
            return _forms;
        }

        public Form Get(int id, string lang)
        {
            _form = dbConnection.GetFormByDrugCode(id, lang);
            return _form;
        }
    }
}