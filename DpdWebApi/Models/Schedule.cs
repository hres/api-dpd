using System;

namespace DpdWebApi.Models
{
    public class Schedule
    {
        public int drug_code { get; set; }
        public String schedule_name { get; set; }
        public DateTime? inactive_date { get; set; }
        public int schedule_code { get; set; }

    }
}