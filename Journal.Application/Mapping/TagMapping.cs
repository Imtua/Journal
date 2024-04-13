namespace Journal.Application.Mapping
{
    public class TagMapping : Profile
    {
        public TagMapping()
        {
            CreateMap<Tag, TagDto>()
                .ForCtorParam("Id", m => m.MapFrom(t => t.Id))
                .ForCtorParam("Title", m => m.MapFrom(t => t.Title))
                .ReverseMap();

            CreateMap<CreateTagDto, Tag>()
                .ForMember(dest => dest.Id, opts =>
                    opts.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Title, opts => 
                    opts.MapFrom(src => src.Title));
        }
    }
}
