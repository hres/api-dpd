using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class DrugProduct
    {
        public int DrugCode { get; set; }
        public string DrugIndentificationNumber { get; set; }
        public string BrandNameE { get; set; }
        public string BrandNameF { get; set; }
        public string DescriptorE { get; set; }
        public string DescriptorF { get; set; }
        public int CompanyCode { get; set; }
        public int NumberOfAis { get; set; }
        public string AiGroupNo { get; set; }
        public string ClassE { get; set; }
        public string ClassF { get; set; }

    }
}