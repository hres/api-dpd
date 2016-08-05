using System;

namespace DpdWebApi.Models
{
    public class Status
    {
        public int DrugCode { get; set; }
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
        public DateTime? HistoryDate { get; set; }
        public DateTime? FirstMarketedDate { get; set; }
        public DateTime? OriginalMarketDate { get; set; }
        public int ExternalStatusCode { get; set; }
    }
}