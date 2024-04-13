namespace Journal.Domain.Contracts.Article
{
    public record ArticleDto(Guid Id, string Title, string Content, string Description, IEnumerable<TagDto> Tags, DateTime DateCreated);
}
