using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using DpdWebApi.Models;
namespace dhpr
{
    /// <summary>
    /// Summary description for Common
    /// </summary>
    public static class UtilityHelper
    {
        public static void SetDefaultCulture(string lang)
        {
            if (lang == "en")
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-CA");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-CA");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");
            }
        }

        public static List<SearchDrug> GetAllDrugProductList(string lang)
        {
            var items = new List<SearchDrug>();
            var filteredList = new List<SearchDrug>();
            var json = string.Empty;
            
            // var postData = new Dictionary<string, string>();
            var dpdJsonUrl = string.Format("{0}&lang={1}", ConfigurationManager.AppSettings["dpdJsonUrl"].ToString(), lang);

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(dpdJsonUrl);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<SearchDrug>>(json);

                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetJSonDataFromDPDAPI()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return items;
        }
        public static List<SearchDrug> GetDrugProductList(string lang, string term)
        {
            // CertifySSL.EnableTrustedHosts();
            var items = new List<SearchDrug>();
            var filteredList = new List<SearchDrug>();
            var json = string.Empty;
            var din = term;
            var brandname = term;
            var company = term;
            // var postData = new Dictionary<string, string>();
            var dpdJsonUrl = string.Format("{0}&din={1}&brandname={2}&company={3}&lang={4}", ConfigurationManager.AppSettings["dpdJsonUrl"].ToString(), din, brandname, company, lang);
            
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(dpdJsonUrl);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<SearchDrug>>(json);

                        //if (items != null && items.Count > 0)
                        //{
                        //     filteredList = items.Where(c => c.DrugIdentificationNumber.ToLower().Contains(term) || c.BrandName.ToLower().Contains(term) || c.CompanyName.ToLower().Contains(term)).ToList();
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetJSonDataFromRegAPI()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return items;
        }

        public static SearchDrug GetDpdByID(string dpdID, string lang)
        {
            // CertifySSL.EnableTrustedHosts();
            var item = new SearchDrug();
            var json = string.Empty;
            var postData = new Dictionary<string, string>();
            var dpdJsonUrlbyID = string.Format("{0}&id={1}&lang={2}", ConfigurationManager.AppSettings["dpdJsonUrl"].ToString(), dpdID, lang);

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(dpdJsonUrlbyID);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        item = JsonConvert.DeserializeObject<SearchDrug>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetDrugProductByID()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return item;
        }
    }
}