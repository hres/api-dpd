using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;


namespace medicalDevice
{
    /// <summary>
    /// Summary description for Common
    /// </summary>
    public static class QueryStringHelper
    {
        
        #region queryString

        public static string GetLang(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "lang") ? queryString["lang"].Trim() : "en";
        }
        public static string GetEstablishmentName(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "estname") ? queryString["estName"] : string.Empty;
        }

        public static string GetReferenceNumber(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "ref") ? queryString["ref"] : string.Empty;
        }

        public static string GetSite(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "site") ? queryString["site"] : string.Empty;
        }

        public static string GetInspectionType(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "instype") ? queryString["insType"] : string.Empty;
        }

        public static string GetRating(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "rate") ? queryString["rate"] : string.Empty;
        }

        public static string GetTermsFlag(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "term") ? queryString["term"] : string.Empty;
        }

        public static string GetInspectionStartDateFrom(this NameValueCollection queryString)
        {
           return queryString.AllKeys.Any(x => x.ToLower() == "insfrom") ? queryString["insFrom"] : string.Empty;
        }

        public static string GetInspectionStartDateTo(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "insto") ? queryString["insTo"] : string.Empty;
        }

        public static string GetCurrentlyLicensed(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "lic") ? queryString["lic"] : string.Empty;
        }
        public static string GetEstablishmentType(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "etype") ? queryString["eType"] : string.Empty;
        }

        public static string GetCategory(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "cat") ? queryString["cat"] : string.Empty;
        }


        public static bool GetReportCard(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "reportcard") ? Convert.ToBoolean(queryString["reportCard"]) : false;
        }

        public static string GetInspectionNumber(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Any(x => x.ToLower() == "insnumber") ? queryString["insNumber"] : string.Empty;
        }
        #endregion

    }
    

}


