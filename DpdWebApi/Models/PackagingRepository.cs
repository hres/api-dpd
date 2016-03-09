using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class PackagingRepository : IPackagingRepository
    {
        private List<Packaging> _packagings = new List<Packaging>();
        private Packaging _packaging = new Packaging();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<Packaging> GetAll()
        {
            _packagings = dbConnection.GetAllPackaging();
            return _packagings;
        }

        public Packaging Get(int id)
        {
            _packaging = dbConnection.GetPackagingByDrugCode(id);
            return _packaging;
        }
    }
}