using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class PharmaceuticalStdRepository : IPharmaceuticalStd
    {
        // We are using the list and _fakeDatabaseID to represent what would
    // most likely be a database of some sort, with an auto-incrementing ID field:
    private List<PharmaceuticalStd> _pharmaceuticalstds = new List<PharmaceuticalStd>();
    private PharmaceuticalStd _pharmaceuticalstd = new PharmaceuticalStd();
    DBConnection dbConnection = new DBConnection("en");
    

    public IEnumerable<PharmaceuticalStd> GetAll(string lang)
    {
        _pharmaceuticalstds = dbConnection.GetAllPharmaceuticalStd(lang);

        return _pharmaceuticalstds;
    }


    public PharmaceuticalStd Get(int id, string lang)
    {
        _pharmaceuticalstd = dbConnection.GetPharmaceuticalStdByDrugCode(id, lang);
        return _pharmaceuticalstd;
    }


    }
}
