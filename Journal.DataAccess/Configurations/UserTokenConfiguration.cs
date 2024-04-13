namespace Journal.DataAccess.Configurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.Property(t => t.RefreshToken).IsRequired();
            builder.Property(t => t.RefreshTokenExpiryTime).IsRequired();

            builder.HasKey(t => t.Id);

            builder.HasData(new List<UserToken>
            {
                new UserToken
                {
                    Id = Guid.NewGuid(),
                    RefreshToken = "QQQQQQ",
                    RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7),
                    UserId = Guid.Parse("cff09933-e686-4448-98ad-7e438f8aa077")
                }
            });
        }
    }
}
