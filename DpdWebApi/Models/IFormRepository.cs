using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IFormRepository
    {
        IEnumerable<Form> GetAll();
        Form Get(int id);
    }
}
