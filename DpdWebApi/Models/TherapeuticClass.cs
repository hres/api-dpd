using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class TherapeuticClass
    {
        public int DrugCode { get; set; }
        public String TcAtcNumber { get; set; }
        public String TcAtc { get; set; }
        public String TcAhfsNumber { get; set; }
        public String TcAhfs { get; set; }
    }
}