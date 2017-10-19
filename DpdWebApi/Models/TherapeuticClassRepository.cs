using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class TherapeuticClassRepository : ITherapeuticClassRepository
    {
        private List<TherapeuticClass> therapeuticClasses = new List<TherapeuticClass>();
        private TherapeuticClass therapeuticClass = new TherapeuticClass();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<TherapeuticClass> GetAll(string lang = "")
        {
            therapeuticClasses = dbConnection.GetAllTherapeuticClass(lang);
            return therapeuticClasses;
        }

        public IEnumerable<TherapeuticClass> Get(int id, string lang = "")
        {
            therapeuticClasses = dbConnection.GetTherapeuticClassByDrugCode(id, lang);
            return therapeuticClasses;
        }
    }
}