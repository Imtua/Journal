namespace Journal.Application.Validations
{
    public class CommentValidator : ICommentValidator
    {
        /// <inheritdoc/>
        public BaseResult CreateValidator(Comment[] comments, User user, Article article)
        {
            if (comments.Length > 3)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.CommentsOverThanThree,
                    ErrorCode = (int)ErrorCodes.CommentsOverThanThree,
                };
            }
            if (user == null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.UserNotFound,
                    ErrorCode = (int)ErrorCodes.UserNotFound,
                };
            }
            if (article == null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.ArticleNotFound,
                    ErrorCode = (int)ErrorCodes.ArticleNotFound,
                };
            }
            return new BaseResult();
        }

        /// <inheritdoc/>
        public BaseResult UpdateValidator(Comment comment, Article article)
        {
            if (comment == null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.CommentNotFound,
                    ErrorCode = (int)ErrorCodes.CommentNotFound,
                };
            }
            if (article == null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.ArticleNotFound,
                    ErrorCode = (int)ErrorCodes.ArticleNotFound,
                };
            }
            if (article.Id != comment.ArticleId)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.ArticleNotFound,
                    ErrorCode = (int)ErrorCodes.ArticleNotFound,
                };
            }
            return new BaseResult();
        }

        public BaseResult ValidateOnNull(Comment obj)
        {
            if (obj == null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.CommentNotFound,
                    ErrorCode = (int)ErrorCodes.CommentNotFound,
                };
            }
            return new BaseResult();
        }
    }
}
