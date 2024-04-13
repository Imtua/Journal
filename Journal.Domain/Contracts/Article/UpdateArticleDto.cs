namespace Journal.Domain.Contracts.Article
{
    public record UpdateArticleDto(Guid Id, string Title, string Content, string Description);
}
