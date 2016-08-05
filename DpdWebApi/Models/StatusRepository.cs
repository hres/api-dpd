using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class StatusRepository : IStatusRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
    // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<Status> _statuses = new List<Status>();
        private Status _status = new Status();
    DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<Status> GetAll(string lang)
    {
        _statuses = dbConnection.GetAllStatus(lang);

        return _statuses;
    }


    public Status Get(int id, string lang)
    {
        _status = dbConnection.GetStatusByDrugCode(id, lang);
        return _status;
    }


    }
}