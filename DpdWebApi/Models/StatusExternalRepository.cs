using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class StatusExternalRepository : IStatusExternalRepository
    {


        private List<StatusExternal> statusesExternal = new List<StatusExternal>();
        private StatusExternal statusExternal = new StatusExternal();
    DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<StatusExternal> GetAll(string lang)
    {
        statusesExternal = dbConnection.GetAllStatusExternal(lang);

        return statusesExternal;
    }


    public StatusExternal Get(int id, string lang)
    {
            statusExternal = dbConnection.GetStatusExternalByStatusCode(id, lang);
        return statusExternal;
    }


    }
}