using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using drug;

namespace DpdWebApi.Controllers
{
    public class CSVController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage DownloadCSV(string dataType, string lang)
        {
            DBConnection dbConnection = new DBConnection(lang);
            var jsonResult = string.Empty;
            var fileNameDate = string.Format("{0}{1}{2}",
                           DateTime.Now.Year.ToString(),
                           DateTime.Now.Month.ToString().PadLeft(2, '0'),
                           DateTime.Now.Day.ToString().PadLeft(2, '0'));
            var fileName = string.Format(dataType + "_{0}.csv", fileNameDate);
            byte[] outputBuffer = null;
            string resultString = string.Empty;
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            var json = string.Empty;

            switch (dataType)
            {
                case "activeIngredient":
                    var activeIngredient = dbConnection.GetAllActiveIngredient(lang).ToList();
                    if (activeIngredient.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(activeIngredient);

                    }
                    break;

                case "company":
                    var company = dbConnection.GetAllCompany(lang).ToList();
                    if (company.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(company);

                    }
                    break;

                case "drugProduct":
                    var drugProduct = dbConnection.GetAllCompany(lang).ToList();
                    if (drugProduct.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(drugProduct);

                    }
                    break;

                case "form":
                    var form = dbConnection.GetAllForm(lang).ToList();
                    if (form.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(form);

                    }
                    break;

                case "packaging":
                    var packaging = dbConnection.GetAllPackaging(lang).ToList();
                    if (packaging.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(packaging);

                    }
                    break;

                case "pharmStd":
                    var pharma = dbConnection.GetAllPharmaceuticalStd().ToList();
                    if (pharma.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(pharma);

                    }
                    break;

                case "schedule":
                    var schedule = dbConnection.GetAllSchedule(lang, "").ToList();
                    if (schedule.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(schedule);

                    }
                    break;

                case "status":
                    var status = dbConnection.GetAllStatus(lang).ToList();
                    if (status.Count > 0)
                    { 
                        json = JsonConvert.SerializeObject(status);
                    }
                    break;

                /*                  no controller for this?
            case "statusEx":
                var statusEx = dbConnection.Get(lang).ToList();
                if (statusEx.Count > 0)
                { 
                    json = JsonConvert.SerializeObject(statusEx);

                }
                break;
                */

                case "route":
                    var route = dbConnection.GetAllRoute(lang).ToList();
                    if (route.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(route);
                    }
                    break;

                case "therapeutic":
                    var therapeutic = dbConnection.GetAllTherapeuticClass(lang).ToList();
                    if (therapeutic.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(therapeutic);
                    }
                    break;

                case "vetSpecies":
                    var vetSpecies = dbConnection.GetAllVeterinarySpecies(lang).ToList();
                    if (vetSpecies.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(vetSpecies);
                    }
                    break;
            }

            if (!string.IsNullOrWhiteSpace(json))
            {
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
                if (dt.Rows.Count > 0)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            UtilityHelper.WriteDataTable(dt, writer, true);
                            outputBuffer = stream.ToArray();
                            resultString = Encoding.UTF8.GetString(outputBuffer, 0, outputBuffer.Length);
                        }
                    }
                    result.Content = new StringContent(resultString);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileName };
                }
            }

            return result;
        }
    }
}
