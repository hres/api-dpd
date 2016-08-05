namespace DpdWebApi.Models
{
    public class DrugVeterinarySpecies
    {
        public int DrugCode { get; set; }
        public int VetSpeciesCode { get; set; }
        public string VetSpeciesName { get; set; } //there is no _E in DB name
    }
}