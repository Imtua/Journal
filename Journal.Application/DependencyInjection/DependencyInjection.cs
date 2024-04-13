namespace Journal.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        => services
            .InitValidators()
            .InitMapper()
            .InitServices()
            .InitFluentValidation();

        private static IServiceCollection InitServices(this IServiceCollection services)
        {
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }

        private static IServiceCollection InitFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(IValidator));
            return services;
        }

        private static IServiceCollection InitValidators(this IServiceCollection services)
        {

            services.AddScoped<IArticleValidator, ArticleValidator>();
            services.AddScoped<ICommentValidator, CommentValidator>();
            services.AddScoped<ITagVlidator, TagVlidator>();
            return services;
        }

        private static IServiceCollection InitMapper(this IServiceCollection services)
        {
            var assemblies = new Type[]
            {
                typeof(ArticleMapping),
                typeof(CommentMapping),
                typeof(TagMapping),
            };

            return services.AddAutoMapper(assemblies);
        }
    }
}
