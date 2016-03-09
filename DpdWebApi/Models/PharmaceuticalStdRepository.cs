using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class PharmaceuticalStdRepository : IPharmaceuticalStdRepository
    {
        private List<PharmaceuticalStd> _pharmaceuticalStds = new List<PharmaceuticalStd>();
        private PharmaceuticalStd _pharmaceuticalStd = new PharmaceuticalStd();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<PharmaceuticalStd> GetAll()
        {
            _pharmaceuticalStds = dbConnection.GetAllPharmaceuticalStd();
            return _pharmaceuticalStds;
        }

        public PharmaceuticalStd Get(int id)
        {
            _pharmaceuticalStd = dbConnection.GetPharmaceuticalStdByDrugCode(id);
            return _pharmaceuticalStd;
        }
    }
}