using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class ActiveIngredient
    {
        public int active_ingredient_id { get; set; }
        public int drug_code { get; set; }
        public string ingredient_name { get; set; }
       
        public string strength_unit { get; set; }
        public string strength { get; set; }
        public int active_ingredient_code { get; set; }
        
        public string dosage_unit { get; set; }
        public string dosage_value { get; set; }

    }
}