using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class oldDrugProductRepositorybk : oldIDrugProductRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
    // most likely be a database of some sort, with an auto-incrementing ID field:
    private List<oldDrugProductbk> _drugProducts = new List<oldDrugProductbk>();
    private oldDrugProductbk _drugProduct = new oldDrugProductbk();
    DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<oldDrugProductbk> GetAll(string lang)
        {
            _drugProducts = null; //dbConnection.GetAllDrugProduct(lang);

            return _drugProducts;
        }


        public oldDrugProductbk Get(int id, string lang)
    {
            _drugProduct = null; // dbConnection.GetDrugProductByDrugCode(id, lang);
        return _drugProduct;
    }

    public oldDrugProductbk Get(string din, string lang)
    {
            _drugProduct = null; //dbConnection.GetDrugProductByDin(din, lang);
        return _drugProduct;
    }


    }
}