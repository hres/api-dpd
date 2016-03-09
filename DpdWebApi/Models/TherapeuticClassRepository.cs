using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class TherapeuticClassRepository : ITherapeuticClassRepository
    {
        private List<TherapeuticClass> _therapeuticClasses = new List<TherapeuticClass>();
        private TherapeuticClass _therapeuticClass = new TherapeuticClass();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<TherapeuticClass> GetAll()
        {
            _therapeuticClasses = dbConnection.GetAllTherapeuticClass();
            return _therapeuticClasses;
        }

        public TherapeuticClass Get(int id)
        {
            _therapeuticClass = dbConnection.GetTherapeuticClassByDrugCode(id);
            return _therapeuticClass;
        }
    }
}