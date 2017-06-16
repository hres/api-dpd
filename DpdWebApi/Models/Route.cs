using System;

namespace DpdWebApi.Models
{
    public class Route
    {
        public int drug_code { get; set; }
        public int route_of_administration_code { get; set; }
        public string route_of_administration_name { get; set; }
        
        //REMOVE public DateTime? inactive_date { get; set; }
    }
}