using Aspen_API.Enums;

namespace Aspen_API.Entities
{
    public class Company : BaseEntity
    {
        public Company(string companyName, string companyDocNumber, string companyAddress, string companyCity, string companyState, string companyZipCode, string companyEmail,int idContactPerson,  int idUser): base()
        {
            CompanyName = companyName;
            CompanyDocNumber = companyDocNumber;
            CompanyAddress = companyAddress;
            CompanyCity = companyCity;
            CompanyState = companyState;
            CompanyZipCode = companyZipCode;
            CompanyEmail = companyEmail;
            IdContactPerson = idContactPerson;
            IdUser = idUser;

            Status = CompanyStatusEnum.Ok;
            Comments = [];
        }
        
        public string CompanyName { get; set; }
        public string CompanyDocNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyZipCode { get; set; }
        public string CompanyEmail { get; set; }
        public int IdContactPerson { get; set; }
        public User ContactPerson { get; set; }
        public int IdUser { get; set; }
        public User FullName { get; set; }
        public CompanyStatusEnum Status { get; set; }
        public List<CompanyComment> Comments { get; set; }

        public void Update(string companyName, string companyDocNumber, string companyAddress, string companyCity, string companyState, string companyZipCode, string companyEmail)
        {
            CompanyName = companyName;
            CompanyDocNumber = companyDocNumber;
            CompanyAddress = companyAddress;
            CompanyCity = companyCity;
            CompanyState = companyState;
            CompanyZipCode = companyZipCode;
            CompanyEmail = companyEmail;
            UpdateAt = DateTime.Now;

        }
    }
}
