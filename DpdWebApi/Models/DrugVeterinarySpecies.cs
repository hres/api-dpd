namespace DpdWebApi.Models
{
    public class DrugVeterinarySpecies
    {
        public int drug_code { get; set; }
        public int vet_species_code { get; set; }
        public string vet_species_name { get; set; } //there is no _E in DB name
    }
}