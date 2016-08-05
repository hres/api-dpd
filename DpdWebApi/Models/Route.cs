using System;

namespace DpdWebApi.Models
{
    public class Route
    {
        public int DrugCode { get; set; }
        public string RouteOfAdministrationName { get; set; }
        public int RouteOfAdministrationCode { get; set; }
        public DateTime? InactiveDate { get; set; }
    }
}