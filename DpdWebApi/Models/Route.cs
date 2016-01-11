using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class Route
    {
        public int DrugCode { get; set; }
        public string RouteOfAdministrationE { get; set; }
        public string RouteOfAdministrationF { get; set; }
        public int RouteOfAdministrationCode { get; set; }
        public DateTime? InactiveDate { get; set; }
    }
}