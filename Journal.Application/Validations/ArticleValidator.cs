namespace Journal.Application.Validations
{
    public class ArticleValidator : IArticleValidator
    {

        /// <inheritdoc/>
        public BaseResult CreateValidator(Article article, User user)
        {
            if (article != null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.ArticleAlreadyExists,
                    ErrorCode = (int)ErrorCodes.ArticleAlreadyExists,
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
            return new BaseResult();
        }

        /// <inheritdoc/>
        public BaseResult ValidateOnNull(Article obj)
        {
            if (obj == null)
            {
                return new BaseResult()
                {
                    ErrorMessage = ErrorMessage.ArticleNotFound,
                    ErrorCode = (int)ErrorCodes.ArticleNotFound,
                };
            }
            return new BaseResult();
        }

        /// <inheritdoc/>
        public BaseResult GetArticleTags(TagDto[] tags)
        {
            if (tags == null || tags.Length == 0)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.TagsNotFound,
                    ErrorCode = (int)ErrorCodes.TagsNotFound,
                };
            }

            return new BaseResult();
        }

        /// <inheritdoc/>
        public BaseResult AddTagToArticleValidator(Article article, Tag tag)
        {
            if (article == null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.ArticleNotFound,
                    ErrorCode = (int)ErrorCodes.ArticleNotFound,
                };
            }

            if (tag == null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.TagNotFound,
                    ErrorCode = (int)ErrorCodes.TagNotFound,
                };
            }

            return new BaseResult();
        }

        /// <inheritdoc/>
        public BaseResult DeleteTagToArticleValidator(Article article, Tag tag)
        {
            if (article == null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.ArticleNotFound,
                    ErrorCode = (int)ErrorCodes.ArticleNotFound,
                };
            }

            if (tag == null && article.Tags!.Contains(tag))
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.TagNotFound,
                    ErrorCode = (int)ErrorCodes.TagNotFound,
                };
            }

            return new BaseResult();
        }
    }
}
