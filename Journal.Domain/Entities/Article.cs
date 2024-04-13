namespace Journal.Domain.Entities
{
    public class Article : IAuditable
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        
        public string Description { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Tag> Tags { get; set; }

        public DateTime CreatedAt { get ; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}
