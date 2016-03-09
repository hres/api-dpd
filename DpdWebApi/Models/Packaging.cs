using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class Packaging
    {
        public int DrugCode { get; set; }
        public String Upc { get; set; }
        public String PackageSizeUnit { get; set; }
        public String PackageType { get; set; }
        public String PackageSize { get; set; }
        public String ProductInformation { get; set; }
    }
}