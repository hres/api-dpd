using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class PharmaceuticalStdRepository : IPharmaceuticalStdRepository
    {

    private List<PharmaceuticalStd> pharmaceuticalstds = new List<PharmaceuticalStd>();
    private PharmaceuticalStd pharmaceuticalstd = new PharmaceuticalStd();

        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<PharmaceuticalStd> GetAll()
    {

       pharmaceuticalstds = dbConnection.GetAllPharmaceuticalStd();

        return pharmaceuticalstds;
    }


    public PharmaceuticalStd Get(int id)
    {
        pharmaceuticalstd = dbConnection.GetPharmaceuticalStdByDrugCode(id);
        return pharmaceuticalstd;
    }


    }
}
