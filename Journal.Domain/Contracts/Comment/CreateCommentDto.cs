namespace Journal.Domain.Contracts.Comment
{
    public record CreateCommentDto(string Text, Guid UserId, Guid ArticleId);
}
