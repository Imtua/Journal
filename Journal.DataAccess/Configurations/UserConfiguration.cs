namespace Journal.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(u => u.Login).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Password).IsRequired();
            
            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Articles)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .HasPrincipalKey(u => u.Id);

            builder.HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .HasPrincipalKey(u => u.Id);

            builder.HasData(new User
            {
                Id = Guid.Parse("cff09933-e686-4448-98ad-7e438f8aa077"),
                Login = "Test User",
                Password = "querty",
                CreatedAt = DateTime.UtcNow,
            });
        }
    }
}
