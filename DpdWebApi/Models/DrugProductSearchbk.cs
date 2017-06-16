using System;
namespace DpdWebApi.Models
{
    public class DrugProductSearchbk
    {
        public int drug_code { get; set; }
        public string drug_identification_number { get; set; }
        public string brand_name { get; set; }
        public string strength { get; set; }
        public string strength_unit_name { get; set; }
        public string company_code { get; set; }
        //public string company_name { get; set; }
        //public string street_name { get; set; }
        //public string city_name { get; set; }
        //public string country_name { get; set; }
        //public string province_name { get; set; }
        //public string postal_code { get; set; }
        //public string suite_number { get; set; }
        public string ai_name { get; set; }
        public string number_of_ais { get; set; }
        public string ai_group_no { get; set; }
        public string schedule_name { get; set; }
        public string class_name { get; set; }
        public string status_name { get; set; }
        public string dosage_value { get; set; }
        public string dosage_unit { get; set; }
        public string atc_name { get; set; }
        public string ahfs_name { get; set; }
        public string pm_name { get; set; }
        public string route_name { get; set; }
        public string form_name { get; set; }
        public DateTime? history_date { get; set; }
        public DateTime? original_market_date { get; set; }
        public int external_status_code { get; set; }
        public Company company { get; set; }
        private string ai_strength_and_dosage = "";
        private string ai_dosage = "";
        public string DosageName
        {
            get
            {
                return this.dosage_unit + " " + this.dosage_value;
            }
        }
   
        public string PMExist
        {
            get
            {
                if (!this.pm_name.Equals("")) {

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
                return this.ai_dosage;
            }
            set
            {
                if (hasData(this.dosage_value))
                {
                    if (hasData(this.dosage_unit))
                    {
                        this.ai_dosage = " / " + this.dosage_value + " " + this.dosage_unit;
                    }
                }
                else {
                    if (!isDosageUnitAPercentage)
                        if (hasData(this.dosage_unit))
                        {
                            this.ai_dosage = " / " + this.dosage_unit;
                        }
                }
            }
        }

        private bool isDosageUnitAPercentage
        {
            get
            {
                bool hasPercentage = false;
                if(hasData(this.dosage_unit))
                {
                    if (this.dosage_unit.Equals("%")) hasPercentage = true;
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
                return this.ai_strength_and_dosage;
            }
            set
            {
                this.ai_strength_and_dosage = AiStrengthText;
                if (!isDosageUnitAPercentage)
                {
                    this.ai_strength_and_dosage += AiDosageText;
                }
            }
            
        }

        public string AiStrengthText
        {
            get
            {
                return this.strength + " " + this.strength_unit_name;
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