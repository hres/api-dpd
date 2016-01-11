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
        public string IngredientNameE { get; set; }
        public string IngredientNameF { get; set; }
        public string StrengthUnitE { get; set; }
        public string StrengthUnitF { get; set; }
        public string Strength { get; set; }
        public int ActiveIngredientCode { get; set; }
        public string DosageUnitE { get; set; }
        public string DosageUnitF { get; set; }
        public string DosageValue { get; set; }

    }
}