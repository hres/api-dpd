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


    public IEnumerable<Status> GetAll()
    {
        _statuses = dbConnection.GetAllStatus();

        return _statuses;
    }


    public Status Get(int id)
    {
        _status = dbConnection.GetStatusByDrugCode(id);
        return _status;
    }


    }
}