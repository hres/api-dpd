using System;
namespace DpdWebApi.Models
{
    public class SearchDrug
    {
        public int DrugCode { get; set; }
        public string DrugIdentificationNumber { get; set; }
        public string BrandName { get; set; }
        public string Strength { get; set; }
        public string StrengthUnitName { get; set; }
        public string CompanyName { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string ProvinceName { get; set; }
        public string PostalCode { get; set; }
        public string SuiteNumber { get; set; }
        public string AiName { get; set; }
        public string NumberOfAis { get; set; }
        public string AiGroupNo { get; set; }
        public string ScheduleName { get; set; }
        public string ClassName { get; set; }
        public string StatusName { get; set; }
        public string DosageValue { get; set; }
        public string DosageUnit { get; set; }
        public string AtcName { get; set; }
        public string AhfsName { get; set; }
        public string PMName { get; set; }
        public string RouteName { get; set; }
        public string FormName { get; set; }
        public DateTime? HistoryDate { get; set; }
        public DateTime? OriginalMarketDate { get; set; }
        public int ExternalStatusCode { get; set; }
        private string strengthName;
        public string DosageName
        {
            get
            {
                return this.DosageUnit + " " + this.DosageValue;
            }
        }
        public string StrengthName
        {
            get
            {
                return this.strengthName;
            }
            set
            {
                this.strengthName = this.Strength + " " + this.StrengthUnitName;
            }
        }
        public string PMExist
        {
            get
            {
                if (!this.PMName.Equals("")) {

                    return "1";
                }
                else
                {
                    return "0";
                }

            }
        }
    }
}