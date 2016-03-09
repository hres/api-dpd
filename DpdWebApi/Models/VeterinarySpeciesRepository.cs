using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class VeterinarySpeciesRepository : IVeterinarySpeciesRepository
    {
        // not quite sure how to pluarize the word species when its already plural
        private List<VeterinarySpecies> _veterinarySpeciess = new List<VeterinarySpecies>();
        private VeterinarySpecies _veterinarySpecies = new VeterinarySpecies();
        DBConnection dbConnection = new DBConnection("en");

        public IEnumerable<VeterinarySpecies> GetAll()
        {
            _veterinarySpeciess = dbConnection.GetAllVeterinarySpecies();
            return _veterinarySpeciess;
        }

        public VeterinarySpecies Get(int id)
        {
            _veterinarySpecies = dbConnection.GetVeterinarySpeciesByDrugCode(id);
            return _veterinarySpecies;
        }
    }
}