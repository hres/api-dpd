using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IStatusRepository
    {
        IEnumerable<Status> GetAll();
        Status Get(int id);
    }
}
