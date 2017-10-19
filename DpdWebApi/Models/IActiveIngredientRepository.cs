using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IActiveIngredientRepository
    {
        IEnumerable<ActiveIngredient> GetAll(string lang="");
        //ActiveIngredient Get(int id, string lang);
        IEnumerable<ActiveIngredient> Get(int id, string lang="");
    }
}
