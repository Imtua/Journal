namespace Journal.Domain.Abstractions.Validations
{
    public interface ICommentValidator : IBaseValidator<Comment>
    {
        /// <summary>
        /// Проверяет наличие комментариев (Comment) под статьей (Article) от введенного пользователя (User).
        /// При наличии более трёх коментариев с одинаковым содержанием запрещает создавать новый.
        /// Проверяется пользователь, если пользователь с Id не существует в БД, то добавление комментария запрещено.
        /// </summary>
        /// <param name="comments"></param>
        /// <param name="user"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        BaseResult CreateValidator(Comment[] comments, User user, Article article);

        /// <summary>
        /// Проверяется наличие комментария (Comment) под статьей (Article) от введенного пользователя (User).
        /// Проверяется статья, если статья с Id не существует в БД, то изменение комментария запрещено.
        /// Проверяется пользователь, если пользователь с Id не существует в БД, то изменение комментария запрещено.
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="user"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        BaseResult UpdateValidator(Comment comment,  Article article);
    }
}
