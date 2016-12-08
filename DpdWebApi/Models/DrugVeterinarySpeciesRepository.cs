using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class DrugVeterinarySpeciesRepository : IDrugVeterinarySpeciesRepository
    {
        // not quite sure how to pluarize the word species when its already plural
        private List<DrugVeterinarySpecies> veterinarySpeciess = new List<DrugVeterinarySpecies>();
        private DrugVeterinarySpecies veterinarySpecies = new DrugVeterinarySpecies();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<DrugVeterinarySpecies> GetAll(string lang)
        {
            veterinarySpeciess = dbConnection.GetAllDrugVeterinarySpecies(lang);
            return veterinarySpeciess;
        }

        public DrugVeterinarySpecies Get(int id, string lang)
        {
            veterinarySpecies = dbConnection.GetDrugVeterinarySpeciesByDrugCode(id, lang);
            return veterinarySpecies;
        }
    }
}