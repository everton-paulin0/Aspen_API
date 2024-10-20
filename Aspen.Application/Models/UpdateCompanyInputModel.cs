using Core.Enums;

namespace Application.Models
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
        public string CompanyEmail { get; set; }
        public int IdUser { get; set; }
        public int IdContactPerson { get; set; }
        public CompanyStatusEnum Status { get; set; }

    }
}
