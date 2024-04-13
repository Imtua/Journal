namespace Journal.Domain.Abstractions.Services
{
    /// <summary>
    ///  Сервис для работы с доменной частью тэгов (Tag).
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// Получение всех тэгов (Tag).
        /// </summary>
        /// <returns></returns>
        Task<CollectionResult<TagDto>> GetTagsAsync();

        /// <summary>
        /// Получение тэга (Tag) по Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<TagDto>> GetTagByIdAsync(Guid id);

        /// <summary>
        /// Создание тэга (Tag) с базовыми параметрами.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        Task<BaseResult<TagDto>> CreateTagAsync(CreateTagDto dto);

        /// <summary>
        /// Обновление тэга (Tag).
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResult<TagDto>> UpdateTagAsync(UpdateTagDto dto);

        /// <summary>
        /// Удаление тэга (Tag) по Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BaseResult<TagDto>> DeleteTagAsync(Guid id);
    }
}
