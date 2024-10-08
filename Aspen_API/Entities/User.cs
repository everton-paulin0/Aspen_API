namespace Aspen_API.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, double mobilePhone) :base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            MobilePhone = mobilePhone;
            IsActive = true;
        }

        public string FullName { get; set; }
        public string Email{ get; set; }
        public DateTime BirthDate { get; set; }
        public double MobilePhone { get; set; }
        public bool IsActive { get; set; }

    }
}
