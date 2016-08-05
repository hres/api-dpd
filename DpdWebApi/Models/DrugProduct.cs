namespace DpdWebApi.Models
{
    public class DrugProduct
    {
        public int DrugCode { get; set; }
        public string DrugIdentificationNumber { get; set; }
        public string BrandName { get; set; }
        public string Descriptor { get; set; }
        public int CompanyCode { get; set; }
        public int NumberOfAis { get; set; }
        public string AiGroupNo { get; set; }
        public string Class { get; set; }

    }
}