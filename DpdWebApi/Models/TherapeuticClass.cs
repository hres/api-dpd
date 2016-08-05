using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class TherapeuticClass
    {
        // The name of this table is TC_FOR_ATC instead of THERAPEUTIC_CLASS
        public int TcAtcCode { get; set; }
        public string TcAtcNumber { get; set; }
        public string TcAtcDescName { get; set; } //there is no _E in the DB

    }
}