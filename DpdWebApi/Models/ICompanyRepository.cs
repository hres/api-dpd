using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface ICompanyRepository
    {
        IEnumerable<Company> GetAll(string lang);
        Company Get(int id, string lang);
    }
}
