namespace Aspen_API.Models
{
    public class CreateCompanyInputModel
    {
        public string CompanyName { get; set; }
        public string CompanyDocNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set;}
        public string CompanyState { get; set; }
        public string CompanyZipCode { get;set; }
        public string Observation { get; set; }
        public int IdContactPerson { get; set; }
    }
}
