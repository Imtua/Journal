namespace Journal.Application.Mapping
{
    public class ArticleMapping : Profile
    {
        public ArticleMapping()
        {
            CreateMap<Article, ArticleDto>()
                .ForCtorParam("Id", m => m.MapFrom(a => a.Id))
                .ForCtorParam("Title", m => m.MapFrom(a => a.Title))
                .ForCtorParam("Content", m => m.MapFrom(a => a.Content))
                .ForCtorParam("Description", m => m.MapFrom(a => a.Description))
                .ForCtorParam("Tags", m => m.MapFrom(a => a.Tags.Select(t => new TagDto(t.Id, t.Title))))
                .ForCtorParam("DateCreated", m => m.MapFrom(a => a.CreatedAt))
                .ReverseMap();

            CreateMap<CreateArticleDto, Article>()
                .ForMember(dest => dest.Id, opts =>
                    opts.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Title, opts =>
                    opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opts =>
                    opts.MapFrom(src => src.Content))
                .ForMember(dest => dest.Description, opts =>
                    opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.UserId, opts =>
                    opts.MapFrom(src => src.UserId));
        }
    }
}
