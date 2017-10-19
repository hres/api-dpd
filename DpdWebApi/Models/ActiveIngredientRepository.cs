using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class ActiveIngredientRepository : IActiveIngredientRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
    // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<ActiveIngredient> activeIngredients = new List<ActiveIngredient>();
        //private ActiveIngredient activeIngredient = new ActiveIngredient();
    DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<ActiveIngredient> GetAll(string lang="")
    {
        activeIngredients = dbConnection.GetAllActiveIngredient(lang);

        return activeIngredients;
    }


    public IEnumerable<ActiveIngredient> Get(int id, string lang="")
    {
            //activeIngredient = dbConnection.GetActiveIngredientByDrugCode(id, lang);
            //return activeIngredient;
            activeIngredients = dbConnection.GetActiveIngredientByDrugCode(id, lang);

            return activeIngredients;
        }


    }
}