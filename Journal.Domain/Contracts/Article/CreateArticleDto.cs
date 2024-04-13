namespace Journal.Domain.Contracts.Article
{
    public record CreateArticleDto(string Title, string Content, string Description, Guid UserId);
}
