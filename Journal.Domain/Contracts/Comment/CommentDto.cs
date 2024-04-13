namespace Journal.Domain.Contracts.Comment
{
    public record CommentDto(Guid Id, string Text, Guid ArticleId, Guid UserId, DateTime DateCreated);
}
