namespace Core.Entities
{
    public class CompanyComment : BaseEntity
    {
        public CompanyComment(string content, int idCompany, int idUser)
        {
            Content = content;
            IdCompany = idCompany;
            IdUser = idUser;
        }
        public string Content { get; set; }
        public int IdCompany { get; set; }
        public Company Company { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
