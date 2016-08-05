using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class DrugProductRepository : IDrugProductRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
    // most likely be a database of some sort, with an auto-incrementing ID field:
    private List<DrugProduct> _drugProducts = new List<DrugProduct>();
    private DrugProduct _drugProduct = new DrugProduct();
    DBConnection dbConnection = new DBConnection("en");


        public IEnumerable<DrugProduct> GetAll(string lang)
        {
            _drugProducts = null; //dbConnection.GetAllDrugProduct(lang);

            return _drugProducts;
        }


        public DrugProduct Get(int id, string lang)
    {
        _drugProduct = dbConnection.GetDrugProductByDrugCode(id, lang);
        return _drugProduct;
    }

    public DrugProduct Get(string din, string lang)
    {
        _drugProduct = dbConnection.GetDrugProductByDin(din, lang);
        return _drugProduct;
    }


    }
}