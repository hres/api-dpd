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
using System.Text;

namespace drug
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

        public static List<DrugProduct> GetAllDrugProductList(string lang, int displayLength, int displayStart)
        {
            var items = new List<DrugProduct>();
            var filteredList = new List<DrugProduct>();
            var json = string.Empty;

            var dpdJsonUrl = string.Format("{0}&lang={1}", ConfigurationManager.AppSettings["dpdJsonUrl"].ToString(), lang);

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    json = webClient.DownloadString(dpdJsonUrl);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<DrugProduct>>(json);

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
        public static List<DrugProduct> GetDrugProductList(string lang, string term, int displayLength, int displayStart)
        {
            var items = new List<DrugProduct>();
            var filteredList = new List<DrugProduct>();
            var json = string.Empty;
            var din = term;
            var brandname = term;
            var company = term;
            
            var dpdJsonUrl = string.Format("{0}&din={1}&brandname={2}&company={3}&lang={4}", ConfigurationManager.AppSettings["dpdJsonUrl"].ToString(), din, brandname, company, lang);
            
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    json = webClient.DownloadString(dpdJsonUrl);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<DrugProduct>>(json);
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

        public static DrugProduct GetDpdByID(string dpdID, string lang)
        {
            // CertifySSL.EnableTrustedHosts();
            var item = new DrugProduct();
            var json = string.Empty;
            var postData = new Dictionary<string, string>();
            var dpdJsonUrlbyID = string.Format("{0}&id={1}&lang={2}", ConfigurationManager.AppSettings["dpdJsonUrl"].ToString(), dpdID, lang);

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    json = webClient.DownloadString(dpdJsonUrlbyID);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        item = JsonConvert.DeserializeObject<DrugProduct>(json);
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