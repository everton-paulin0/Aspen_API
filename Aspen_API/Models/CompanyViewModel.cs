using Aspen_API.Entities;
using System.Xml.Linq;

namespace Aspen_API.Models
{
    public class CompanyViewModel
    {
        public CompanyViewModel(int id, string companyName, string companyDocNumber, string companyAddress, string companyCity, string companyState, string companyZipCode, int idContactPerson, int idUser, List<CompanyComment> comments)
        {
            Id = id;
            CompanyName = companyName;
            CompanyDocNumber = companyDocNumber;
            CompanyAddress = companyAddress;
            CompanyCity = companyCity;
            CompanyState = companyState;
            CompanyZipCode = companyZipCode;
            IdContactPerson = idContactPerson;
            IdUser = idUser;
            Comments = comments.Select(c => c.Content).ToList();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDocNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyZipCode { get; set; }
        public int IdContactPerson { get; set; }        
        public int IdUser { get; set; }        
        public List<string> Comments { get; set; }

        public static CompanyViewModel FromEntity(Company entity)
            => new(entity.Id, entity.CompanyName, entity.CompanyDocNumber, 
                entity.CompanyAddress, entity.CompanyCity, entity.CompanyState, 
                entity.CompanyZipCode,  entity.IdContactPerson, 
                entity.IdUser,entity.Comments);
    }
}
