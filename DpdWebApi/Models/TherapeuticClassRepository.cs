using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class TherapeuticClassRepository : ITherapeuticClassRepository
    {
        private List<TherapeuticClass> _therapeuticClasses = new List<TherapeuticClass>();
        private TherapeuticClass _therapeuticClass = new TherapeuticClass();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<TherapeuticClass> GetAll(string lang)
        {
            _therapeuticClasses = dbConnection.GetAllTherapeuticClass(lang);
            return _therapeuticClasses;
        }

        public TherapeuticClass Get(int id, string lang)
        {
            _therapeuticClass = dbConnection.GetTherapeuticClassByDrugCode(id, lang);
            return _therapeuticClass;
        }
    }
}