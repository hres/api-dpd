using drug;
using System.Collections.Generic;

namespace DpdWebApi.Models
{
    public class CompanyRepository : ICompanyRepository
    {
        // We are using the list and _fakeDatabaseID to represent what would
    // most likely be a database of some sort, with an auto-incrementing ID field:
        private List<Company> _companies = new List<Company>();
        private Company _company = new Company();
    DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<Company> GetAll()
    {
        _companies = dbConnection.GetAllCompany();

        return _companies;
    }


    public Company Get(int id)
    {
        _company = dbConnection.GetCompanyByCompanyCode(id);
        return _company;
    }


    }
}