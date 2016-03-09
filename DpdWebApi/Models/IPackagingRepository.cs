﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DpdWebApi.Models
{
    interface IPackagingRepository
    {
        IEnumerable<Packaging> GetAll();
        Packaging Get(int id);
    }
}
