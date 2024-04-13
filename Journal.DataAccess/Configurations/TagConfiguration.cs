namespace Journal.DataAccess.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");

            builder.Property(t => t.Title).IsRequired();

            builder.HasKey(t => t.Id);

            builder.HasMany(t => t.Articles)
                .WithMany(a => a.Tags);

            builder.HasData(
                new Tag
                {
                    Id = Guid.Parse("ae4f8d18-2f24-4497-bf0d-08f428c8cab0"),
                    Title = "Спорт",
                    CreatedAt = DateTime.UtcNow,
                },
                new Tag
                {
                    Id = Guid.Parse("ae38013a-a9ca-4029-96cf-3d91fe30fc8f"),
                    Title = "Музыка",
                    CreatedAt = DateTime.UtcNow,
                },
                new Tag
                {
                    Id = Guid.Parse("3ef9b2a3-3759-492c-bb8a-8710a3553081"),
                    Title = "Кино",
                    CreatedAt = DateTime.UtcNow,
                },
                new Tag
                {
                    Id = Guid.Parse("0d52f8ef-1ce1-49d1-b126-26989af3250d"),
                    Title = "IT",
                    CreatedAt = DateTime.UtcNow,
                });
        }
    }
}
