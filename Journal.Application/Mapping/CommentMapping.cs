namespace Journal.Application.Mapping
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, CommentDto>()
                .ForCtorParam("Id", m => m.MapFrom(c => c.Id))
                .ForCtorParam("Text", m => m.MapFrom(c => c.Text))
                .ForCtorParam("ArticleId", m => m.MapFrom(c => c.ArticleId))
                .ForCtorParam("UserId", m => m.MapFrom(c => c.UserId))
                .ForCtorParam("DateCreated", m => m.MapFrom(c => c.CreatedAt))
                .ReverseMap();

            CreateMap<CreateCommentDto, Comment>()
                .ForMember(dest => dest.Id,
                opts => opts.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Text,
                opts => opts.MapFrom(src => src.Text))
                .ForMember(dest => dest.UserId,
                opts => opts.MapFrom(src => src.UserId))
                .ForMember(dest => dest.ArticleId,
                opts => opts.MapFrom(src => src.ArticleId));
        }
    }
}
