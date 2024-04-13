namespace Journal.Domain.Entities
{
    public class Comment : IAuditable
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }

        public Article Article { get; set; }

        public Guid ArticleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}
