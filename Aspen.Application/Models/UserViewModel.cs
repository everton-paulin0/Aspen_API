using Core.Entities;

namespace Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, double mobilePhone, int idCompany)
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

        public List<string> Comments { get; set; }

        public static UserViewModel FromEntity (User user)
        {
            var comments = user.Comments.Select(u=> u.Content).ToList();

            return new (user.FullName, user.Email, user.BirthDate, user.MobilePhone, user.IdCompany);
        }
    }
}
