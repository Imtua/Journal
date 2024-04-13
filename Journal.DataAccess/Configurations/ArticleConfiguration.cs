namespace Journal.DataAccess.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");

            builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(300);

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.User)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(a => a.Comments)
                .WithOne(c => c.Article)
                .HasForeignKey(c => c.ArticleId)
                .HasPrincipalKey(a => a.Id);

            builder.HasMany(a => a.Tags)
                .WithMany(t => t.Articles);

            builder.HasData(
                new Article
                {
                    Id = Guid.Parse("382b5a7b-d39a-4a76-b848-33cd03210187"),
                    Title = "Test Article1",
                    Content = "Test Content1",
                    Description = "Test Description1",
                    UserId = Guid.Parse("cff09933-e686-4448-98ad-7e438f8aa077"),
                    CreatedAt = DateTime.UtcNow,
                },
                new Article
                {
                    Id = Guid.Parse("c920547f-7075-4bff-8182-7960f63521bf"),
                    Title = "Test Article2",
                    Content = "Test Content2",
                    Description = "Test Description2",
                    UserId = Guid.Parse("cff09933-e686-4448-98ad-7e438f8aa077"),
                    CreatedAt = DateTime.UtcNow,
                }); ;
        }
    }
}
