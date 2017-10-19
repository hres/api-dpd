using System;

namespace DpdWebApi.Models
{
    public class Status
    {
        public int drug_code { get; set; }
        //public int status_code { get; set; }
        public string status { get; set; }
        public DateTime? history_date { get; set; }
        //public DateTime? first_marketed_date { get; set; }
        public DateTime? original_market_date { get; set; }
        public int external_status_code { get; set; }
        public DateTime? expiration_date { get; set; }
        //public int lot_number { get; set; }
        public string lot_number { get; set; }
    }
}