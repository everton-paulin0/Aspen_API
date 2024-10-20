using Core.Entities;
using Core.Enums;

namespace Application.Models
{
    public class CreateCompanyInputModel
    {
        public string CompanyName { get; set; }
        public string CompanyDocNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set;}
        public string CompanyState { get; set; }
        public string CompanyZipCode { get;set; }
        public string CompanyEmail { get; set; }
        public CompanyStatusEnum Status {  get; set; }
        public int IdUser { get; set; }
        public int IdContactPerson { get; set; }

        public Company ToEntity() => new(CompanyName, CompanyDocNumber, CompanyAddress, CompanyCity, CompanyState, CompanyZipCode, CompanyEmail, IdUser, IdContactPerson);
    }
}
