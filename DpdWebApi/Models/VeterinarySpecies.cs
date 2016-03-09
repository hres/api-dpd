using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class VeterinarySpecies
    {
        public int DrugCode { get; set; }
        public String VetSpecies { get; set; }
        public String VetSubSpecies { get; set; }
    }
}