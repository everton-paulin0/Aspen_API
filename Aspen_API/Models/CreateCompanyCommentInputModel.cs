namespace Aspen_API.Models
{
    public class CreateCompanyCommentInputModel
    {
        public string Content { get; set; }
        public int IdCompany { get; set; }
        public int IdUser { get; set; }
    }
}
