using System;

namespace DpdWebApi.Models
{
    public class StatusExternal
    {
        public int external_status_code { get; set; }
        public string external_status_name { get; set; }
        public DateTime? inactive_date { get; set; }
        
    }
}