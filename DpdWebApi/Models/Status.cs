using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class Status
    {
        public int DrugCode { get; set; }
        public int StatusCode { get; set; }
        public string StatusE { get; set; }
        public string StatusF { get; set; }
        public DateTime? HistoryDate { get; set; }
        public DateTime? FirstMarketedDate { get; set; }
        public DateTime? OriginalMarketDate { get; set; }
        public int ExternalStatusCode { get; set; }
    }
}