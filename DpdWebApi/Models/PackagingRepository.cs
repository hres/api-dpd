using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class PackagingRepository : IPackagingRepository
    {
        private List<Packaging> packagings = new List<Packaging>();
        private Packaging packaging = new Packaging();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Packaging> GetAll(string lang)
        {
            packagings = dbConnection.GetAllPackaging(lang);
            return packagings;
        }

        public Packaging Get(int id, string lang)
        {
            packaging = dbConnection.GetPackagingByDrugCode(id, lang);
            return packaging;
        }
    }
}