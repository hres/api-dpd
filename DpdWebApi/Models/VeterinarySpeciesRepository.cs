using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class VeterinarySpeciesRepository : IVeterinarySpeciesRepository
    {
        // not quite sure how to pluarize the word species when its already plural
        private List<VeterinarySpecies> veterinarySpeciess = new List<VeterinarySpecies>();
        private VeterinarySpecies veterinarySpecies = new VeterinarySpecies();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<VeterinarySpecies> GetAll(string lang)
        {
            veterinarySpeciess = dbConnection.GetAllVeterinarySpecies(lang);
            return veterinarySpeciess;
        }

        public IEnumerable<VeterinarySpecies> Get(int id, string lang)
        {
            veterinarySpeciess = dbConnection.GetVeterinarySpeciesByDrugCode(id, lang);
            return veterinarySpeciess;
        }
    }
}