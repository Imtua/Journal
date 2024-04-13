namespace Journal.Application.Validations
{
    public class TagVlidator : ITagVlidator
    {
        /// <inheritdoc/>
        public BaseResult CreateValidator(Tag tag)
        {
            if (tag != null)
            {
                return new BaseResult
                {
                    ErrorMessage = ErrorMessage.TagAlreadyExists,
                    ErrorCode = (int)ErrorCodes.TagAlreadyExists,
                };
            }
            return new BaseResult();
        }

        /// <inheritdoc/>
        public BaseResult ValidateOnNull(Tag obj)
        {
            if (obj == null)
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
