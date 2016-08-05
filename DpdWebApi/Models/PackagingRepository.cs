using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class PackagingRepository : IPackagingRepository
    {
        private List<Packaging> _packagings = new List<Packaging>();
        private Packaging _packaging = new Packaging();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Packaging> GetAll(string lang)
        {
            _packagings = dbConnection.GetAllPackaging(lang);
            return _packagings;
        }

        public Packaging Get(int id, string lang)
        {
            _packaging = dbConnection.GetPackagingByDrugCode(id, lang);
            return _packaging;
        }
    }
}