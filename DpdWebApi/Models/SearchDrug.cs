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
        private string AiStrengthAndDosage = "";
        private string AiDosage = "";
        public string DosageName
        {
            get
            {
                return this.DosageUnit + " " + this.DosageValue;
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

        public string AiDosageText
        {
            get
            {
                return AiDosage;
            }
            set
            {
                if (hasData(DosageValue))
                {
                    if (hasData(DosageUnit))
                    {
                        AiDosage = " / " + DosageValue + " " + DosageUnit;
                    }
                }
                else {
                    if (!isDosageUnitAPercentage)
                        if (hasData(DosageUnit))
                        {
                            AiDosage = " / " + DosageUnit;
                        }
                }
            }
        }

        private bool isDosageUnitAPercentage
        {
            get
            {
                bool hasPercentage = false;
                if(hasData(DosageUnit))
                {
                    if (DosageUnit.Equals("%")) hasPercentage = true;
                }
                return hasPercentage;
            }

        }

        /**
     * Sylvain Larivière 2009-12-07
     * @return active ingredient strength in the form &lt;strength&gt; &lt;unit&gt;
     *  for instance " 100 MG", or ".2 %".
     *  Dosage (eg "per tablet" or "per ml") is delegated to getDosageText()
     *  @see getDosageText().
     */
        public string AiStrengthAndDosageText
        {
            get
            {
                return AiStrengthAndDosage;
            }
            set
            {
                AiStrengthAndDosage = AiStrengthText;
                if (!isDosageUnitAPercentage)
                {
                    AiStrengthAndDosage += AiDosageText;
                }
            }
            
        }

        public string AiStrengthText
        {
            get
            {
                return Strength + " " + StrengthUnitName;
            }
        }

        /**
     * @param A String s
     * @return True if the passed String is null or has a zero length; false otherwise.
     * @author Sylvain Larivière 2012-06-27
     */
        public static bool isEmpty(string s)
        {
            return (s == null || s.Trim().Length < 1) || s.Trim().Equals("");
        }

        /**
         * @param A String s
         * @return True if the passed String is not null and has a length greater than zero; false otherwise.
         * @author Sylvain Larivière 2012-06-27
         */
        public static bool hasData(string s)
        {
            return (s != null && s.Trim().Length > 0);
        }

    }
}