namespace DpdWebApi.Models
{
    public class VeterinarySpecies
    {
        public int drug_code { get; set; }
        //REMOVE public int vet_species_code { get; set; }
        public string vet_species_name { get; set; } //there is no _E in DB name
        //NOT NEED vet_sub_species not in DB
    }
}