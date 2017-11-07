using System;
namespace DpdWebApi.Models
{
    public class DrugProduct
    {
        public int drug_code { get; set; }
        public string class_name { get; set; }
        public string drug_identification_number { get; set; }
        public string brand_name { get; set; }
        public string descriptor { get; set; }
        public string number_of_ais { get; set; }
        //last_update_date not there
        public string ai_group_no { get; set; }
        
        public string company_name { get; set; }
        //public Company company { get; set; }
    }
}