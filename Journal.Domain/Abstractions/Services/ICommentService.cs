namespace Journal.Domain.Abstractions.Services
{
    /// <summary>
    ///  Сервис, отвечающий за работу с доменной частью коментариев (Comment).
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Получение комментария (Comment) по Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<CommentDto>> GetByIdAsync(Guid id);

        /// <summary>
        /// Получение всех коментариев статьи (Article).
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        Task<CollectionResult<CommentDto>> GetCommentsByArticleIdAsync(Guid articleId);

        /// <summary>
        /// Получение всех коментариев пользователя (User).
        /// </summary>
        /// <returns></returns>
        Task<CollectionResult<CommentDto>> GetCommentsByUserId(Guid userId);

        /// <summary>
        /// Создание комментария (Comment) с базовыми параметрами.
        /// </summary>
        /// <param name="dto">Модель с первичными данными.</param>
        /// <returns></returns>
        Task<BaseResult<CommentDto>> CreateCommentAsync(CreateCommentDto dto);

        /// <summary>
        /// Обновление комментария (Comment).
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResult<CommentDto>> UpdateCommentAsync(UpdateCommentDto dto);

        /// <summary>
        /// Удаление комментария (Comment) по Id.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        Task<BaseResult<CommentDto>> DeleteCommentAsync(Guid commentId);
    }
}
