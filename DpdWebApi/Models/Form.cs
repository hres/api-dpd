using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class Form
    {
        public int DrugCode { get; set; }
        public DateTime? InactiveDate { get; set; }
        public int PharmaceuticalFormCode { get; set; }
        public string PharmaceuticalFormE { get; set; } //DB Entry has no _E
        public string PharmaceuticalFormF { get; set; }
    }
}