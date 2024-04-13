namespace Journal.DataAccess.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
            => services
            .InitInterceptors()
            .AddPostgres(configuration)
            .InitRepositories();

        private static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgresSQL");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }

        private static IServiceCollection InitInterceptors(this IServiceCollection services)
        {
            services.AddSingleton<DateInterceptor>();

            return services;
        }

        private static IServiceCollection InitRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseRepository<Article>, BaseRepository<Article>>();
            services.AddScoped<IBaseRepository<Tag>, BaseRepository<Tag>>();
            services.AddScoped<IBaseRepository<UserToken>, BaseRepository<UserToken>>();
            services.AddScoped<IBaseRepository<Comment>, BaseRepository<Comment>>();

            return services;
        }
    }
}
