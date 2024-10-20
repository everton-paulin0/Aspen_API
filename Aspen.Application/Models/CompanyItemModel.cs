using Core.Entities;
using Core.Enums;

namespace Application.Models
{
    public class CompanyItemModel
    {
        public CompanyItemModel(int id, string companyName, string companyDocNumber, string companyAddress, string companyCity, string companyState, string companyZipCode, string companyEmail)
        {
            Id = id;
            CompanyName = companyName;
            CompanyDocNumber = companyDocNumber;
            CompanyAddress = companyAddress;
            CompanyCity = companyCity;
            CompanyState = companyState;
            CompanyZipCode = companyZipCode;
            CompanyEmail = companyEmail;
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDocNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyZipCode { get; set; }
        public string CompanyEmail { get; set; }
        public int IdUser { get; set; }
        public CompanyStatusEnum Status { get; set; }

        public static CompanyItemModel FromEntity(Company company)
            => new(company.Id, company.CompanyEmail, company.CompanyDocNumber, company.CompanyAddress, company.CompanyCity, company.CompanyState, company.CompanyZipCode, company.CompanyEmail);

    }
}
