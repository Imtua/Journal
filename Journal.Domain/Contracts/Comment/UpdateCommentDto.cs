namespace Journal.Domain.Contracts.Comment
{
    public record UpdateCommentDto(Guid Id, string Text, Guid ArticleId, Guid UserId);
}
