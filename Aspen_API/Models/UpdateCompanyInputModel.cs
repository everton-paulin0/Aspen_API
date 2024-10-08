namespace Aspen_API.Models
{
    public class UpdateCompanyInputModel
    {
        public int IdCompany { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDocNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyZipCode { get; set; }
        public string Observation { get; set; }
    }
}
