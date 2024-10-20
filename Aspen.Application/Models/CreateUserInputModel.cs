namespace Application.Models
{
    public class CreateUserInputModel
    {
        public CreateUserInputModel(string fullName, string email, DateTime birthDate, double mobilePhone, int idCompany)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            MobilePhone = mobilePhone;
            IdCompany = idCompany;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double MobilePhone { get; set; }
        public int IdCompany { get; set; }
        public bool IsActive { get; set; }
    }
}
