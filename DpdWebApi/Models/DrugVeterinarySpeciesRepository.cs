using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class DrugVeterinarySpeciesRepository : IDrugVeterinarySpeciesRepository
    {
        // not quite sure how to pluarize the word species when its already plural
        private List<DrugVeterinarySpecies> _veterinarySpeciess = new List<DrugVeterinarySpecies>();
        private DrugVeterinarySpecies _veterinarySpecies = new DrugVeterinarySpecies();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<DrugVeterinarySpecies> GetAll()
        {
            _veterinarySpeciess = dbConnection.GetAllDrugVeterinarySpecies();
            return _veterinarySpeciess;
        }

        public DrugVeterinarySpecies Get(int id)
        {
            _veterinarySpecies = dbConnection.GetDrugVeterinarySpeciesByDrugCode(id);
            return _veterinarySpecies;
        }
    }
}