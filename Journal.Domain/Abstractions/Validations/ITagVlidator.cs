namespace Journal.Domain.Abstractions.Validations
{
    public interface ITagVlidator : IBaseValidator<Tag>
    {
        /// <summary>
        /// Если тэг с введенным названием существует в БД, создание дубликата запрещено.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        BaseResult CreateValidator(Tag tag);
    }
}
