namespace Journal.Domain.Abstractions.Services
{
    /// <summary>
    /// Сервис для работы с доменной частью статьи (Article).
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Получение всех статей (Article).
        /// </summary>
        /// <returns></returns>
        Task<CollectionResult<ArticleDto>> GetArticlesAsync();

        /// <summary> 
        /// Получение всех статей (Article) пользователя (User).
        /// </summary>
        /// <param name="id">Id пользователя.</param>
        /// <returns>Коллекция статей (Article).</returns>
        Task<CollectionResult<ArticleDto>> GetUserArticlesAsync(Guid userId);

        /// <summary>
        /// Получение статьи (Article) по Id.
        /// </summary>
        /// <param name="id">Id статьи (Article).</param>
        /// <returns>Статья (Article) по указаному Id.</returns>
        Task<BaseResult<ArticleDto>> GetArticleByIdAsync(Guid id);
     
        /// <summary>
        /// Создание статьи (Article) с базовыми параметрами.
        /// </summary>
        /// <param name="dto">Модель с первичными данными.</param>
        /// <returns></returns>
        Task<BaseResult<ArticleDto>> CreateArticleAsync(CreateArticleDto dto);

        /// <summary>
        /// Удаление статьи (Article) по Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<ArticleDto>> DeleteArticleAsync(Guid id); 

        /// <summary>
        /// Обновление статьи (Article).
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResult<ArticleDto>> UpdateArticleAsync(UpdateArticleDto dto);


        /// <summary>
        /// Получить коллекцию тэгов (Tag) у статьи (Article) по Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CollectionResult<TagDto>> GetTagsByArticleId(Guid id);

        /// <summary>
        /// Добавить тэг (Tag) к статье (Article).
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResult<ArticleDto>> AddTagToArticleAsync(Guid articleId, Guid tagId);

        /// <summary>
        /// Удалить тэг (Tag) у статьи (Article).
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        Task<BaseResult<TagDto>> DeleteTagToArticleAsync(Guid articleId, Guid tagId);
    }
}
