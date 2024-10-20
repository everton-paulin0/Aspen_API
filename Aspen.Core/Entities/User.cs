namespace Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, double mobilePhone, int idCompany) :base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            MobilePhone = mobilePhone;
            IsActive = true;
            IdCompany = idCompany;

            Companies = [];
            Comments = [];
        }

        public string FullName { get; set; }
        public string Email{ get; set; }
        public DateTime BirthDate { get; set; }
        public double MobilePhone { get; set; }
        public bool IsActive { get; set; }
        public int IdCompany { get; set; }
        public List<Company> Companies { get; set; }

        public List<CompanyComment> Comments { get; set; }

    }
}
