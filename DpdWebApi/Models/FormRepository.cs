using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class FormRepository : IFormRepository
    {
        private List<Form> _forms = new List<Form>();
        private Form _form = new Form();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Form> GetAll()
        {
            _forms = dbConnection.GetAllForm();
            return _forms;
        }

        public Form Get(int id)
        {
            _form = dbConnection.GetFormByDrugCode(id);
            return _form;
        }
    }
}