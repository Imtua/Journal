namespace Journal.Domain.Entities
{
    public class User : IAuditable
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserToken UserToken { get; set; }

        public List<Article> Articles { get; set; }

        public List<Comment> Comments { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}
