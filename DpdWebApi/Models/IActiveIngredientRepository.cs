using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IActiveIngredientRepository
    {
        IEnumerable<ActiveIngredient> GetAll();
        ActiveIngredient Get(int id);
    }
}
