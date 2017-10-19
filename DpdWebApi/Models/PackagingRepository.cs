using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class PackagingRepository : IPackagingRepository
    {
        private List<Packaging> packagings = new List<Packaging>();
        private Packaging packaging = new Packaging();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Packaging> GetAll()
        {
            packagings = dbConnection.GetAllPackaging();
            return packagings;
        }

        public Packaging Get(int id)
        {
            packaging = dbConnection.GetPackagingByDrugCode(id);
            return packaging;
        }
    }
}