using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class Form
    {
        public int drug_code { get; set; }
        //REMOVE public DateTime? inactive_date { get; set; }
        public int pharmaceutical_form_code { get; set; }
        public string pharmaceutical_form_name { get; set; } //DB Entry has no _E
    }
}