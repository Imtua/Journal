
namespace Journal.DataAccess.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.Property(c => c.Text).IsRequired().HasMaxLength(1000);

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ArticleId)
                .HasPrincipalKey(a => a.Id);

            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .HasPrincipalKey(u => u.Id);
        }
    }
}
