using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class ActiveIngredientRepository : IActiveIngredientRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
    // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<ActiveIngredient> _activeIngredients = new List<ActiveIngredient>();
        private ActiveIngredient _activeIngredient = new ActiveIngredient();
    DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<ActiveIngredient> GetAll()
    {
        _activeIngredients = dbConnection.GetAllActiveIngredient();

        return _activeIngredients;
    }


    public ActiveIngredient Get(int id)
    {
        _activeIngredient = dbConnection.GetActiveIngredientById(id);
        return _activeIngredient;
    }


    }
}