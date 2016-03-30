using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class DrugVeterinarySpecies
    {
        public int DrugCode { get; set; }
        public int VetSpeciesCode { get; set; }
        public string VetSpeciesE { get; set; } //there is no _E in DB name
        public string VetSpeciesF { get; set; }
    }
}