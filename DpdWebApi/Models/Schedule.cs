using System;

namespace DpdWebApi.Models
{
    public class Schedule
    {
        public int DrugCode { get; set; }
        public String ScheduleName { get; set; }
        public DateTime? InactiveDate { get; set; }
        public int ScheduleCode { get; set; }

    }
}