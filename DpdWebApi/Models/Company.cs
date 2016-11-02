using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class Company
    {
        public int company_code { get; set; }
        public string mfr_code { get; set; }
        public string company_name { get; set; }
        public string company_type { get; set; }
        public string suite_number { get; set; }
        public string city_name { get; set; }
        public string street_name { get; set; }
        public string province_name { get; set; }
        public string country_name { get; set; }
        public string postal_code { get; set; }
        public string post_office_box { get; set; }
    }
}