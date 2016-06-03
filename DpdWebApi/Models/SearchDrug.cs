using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class SearchDrug
    {
        public int DrugCode { get; set; }
        public string DrugIdentificationNumber { get; set; }

        public string BrandName { get; set; }
    
        public string Strength { get; set; }
        public string StrengthUnitName { get; set; }
        public string CompanyName { get; set; }
        public string AiName { get; set; }
        public int NumberOfAis { get; set; }
        public string AiGroupNo { get; set; }
        public string ScheduleName { get; set; }
        public string ClassName { get; set; }

        public string StatusName { get; set; }
        public string DosageValue { get; set; }
        public string DosageUnit { get; set; }
        public string PM { get; set; }

    }
}