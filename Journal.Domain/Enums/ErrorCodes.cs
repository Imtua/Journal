namespace Journal.Domain.Enums
{
    public enum ErrorCodes
    {
        // Article 0 - 10
        ArticlesNotFound = 0,
        ArticleNotFound = 1,
        ArticleAlreadyExists = 2,

        // User 11 - 20
        UserNotFound = 11,
        UserAlreadyExists = 12,

        // Tag 21-30
        TagsNotFound = 21,
        TagNotFound = 22,
        TagAlreadyExists = 23,
        TagAlreadyAppends = 24,

        // Comment 31-40
        CommentsNotFound = 31,
        CommentNotFound = 32,
        CommentsOverThanThree = 33,

        // Auth 41-50
        PasswordNotEqualPasswordConfirm = 41,
        PasswordIsWrong = 42,

        // Common
        InternalServerError = 500,
    }
}
