namespace Aspen_API.Models
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

    }
}
