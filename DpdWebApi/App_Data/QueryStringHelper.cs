using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;


namespace dhpr
{
    /// <summary>
    /// Summary description for Common
    /// </summary>
    public static class QueryStringHelper
    {
        #region queryString
  
        public static string GetLang(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Contains("lang") ? queryString["lang"] : string.Empty;
        }
        public static string GetSearchTerm(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Contains("term") ? queryString["term"] : string.Empty;
        }
        public static string GetLinkID(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Contains("linkID") ? queryString["linkID"] : string.Empty;
        }
        public static string GetProgramType(this NameValueCollection queryString)
        {
            return queryString.AllKeys.Contains("pType") ? queryString["pType"] : string.Empty;
        }        
        #endregion

    }

}


