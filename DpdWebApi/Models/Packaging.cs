using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class Packaging
    {
        public int packaging_id { get; set; }
        public int drug_code { get; set; }
        public String upc { get; set; }
        public String package_size_unit { get; set; }
        public String package_type { get; set; }
        public String package_size { get; set; }
        public String product_information { get; set; }
    }
}