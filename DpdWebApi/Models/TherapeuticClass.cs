using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class TherapeuticClass
    {
        // The name of this table is TC_FOR_ATC instead of THERAPEUTIC_CLASS
        public int drug_code { get; set; }
        public string tc_atc_number { get; set; }
        public string tc_atc { get; set; }
        //public string tc_ahfs_number { get; set; }
        //public string tc_ahfs { get; set; }

    }
}