namespace Journal.Domain.Abstractions.Validations
{
    public interface IArticleValidator : IBaseValidator<Article>
    {
        /// <summary>
        /// Проверяется наличие статьи (Article) у пользователя (User).
        /// Если статья с введенным названием существует в БД, создание дубликата запрещено.
        /// Проверяется пользователь, если пользователь с Id не существует в БД, то добавление статьи запрещено.
        /// </summary>
        /// <param name="article"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        BaseResult CreateValidator(Article article, User user);

        /// <summary>
        /// Проверяет наличие тэгов (TagDto[]) на null.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        BaseResult GetArticleTags(TagDto[] tags);

        /// <summary>
        /// Проверяет наличие статьи (Article) и тэга (Tag).
        /// </summary>
        /// <param name="article"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        BaseResult AddTagToArticleValidator(Article article, Tag tag);

        /// <summary>
        /// Проверить параметры на null и наличие тэга (Tag) у статьи (Article).
        /// </summary>
        /// <param name="article"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        BaseResult DeleteTagToArticleValidator(Article article, Tag tag);
    }
}
