namespace Journal.Domain.Entities
{
    public class Tag : IAuditable, IEquatable<Tag>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public List<Article> Articles { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool Equals(Tag other)
        {
            if (other is Tag tag)
            {
                return Id == tag.Id && Title == tag.Title;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}
