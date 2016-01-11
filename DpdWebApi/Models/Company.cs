﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DpdWebApi.Models
{
    public class Company
    {
        public int CompanyCode { get; set; }
        public string MfrCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string SuiteNumber { get; set; }
        public string CityName { get; set; }
        public string StreetNameE { get; set; }
        public string StreetNameF { get; set; }
        public string ProvinceE { get; set; }
        public string ProvinceF { get; set; }
        public string CountryE { get; set; }
        public string CountryF { get; set; }
        public string PostalCode { get; set; }
        public string PostOfficeBox { get; set; }
    }
}