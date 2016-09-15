using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class ActiveIngredient
    {
        public int ActiveIngredientId { get; set; }
        public int DrugCode { get; set; }
        public string IngredientName { get; set; }
       
        public string StrengthUnit { get; set; }
        public string Strength { get; set; }
        public int ActiveIngredientCode { get; set; }
        
        public string DosageUnit { get; set; }
        public string DosageValue { get; set; }

    }
}