using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IScheduleRepository
    {
        IEnumerable<Schedule> GetAll(string lang);
        Schedule Get(int id, string lang);
    }
}
