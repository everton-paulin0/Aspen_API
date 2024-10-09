namespace Aspen_API.Models
{
    public class CreateUserInputModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double MobilePhone { get; set; }
        public bool IsActive { get; set; }
    }
}
