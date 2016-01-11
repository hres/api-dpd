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
    

    public IEnumerable<DrugProduct> GetAll()
    {
        _drugProducts = dbConnection.GetAllDrugProduct();

        return _drugProducts;
    }


    public DrugProduct Get(int id)
    {
        _drugProduct = dbConnection.GetDrugProductByDrugCode(id);
        return _drugProduct;
    }


    }
}