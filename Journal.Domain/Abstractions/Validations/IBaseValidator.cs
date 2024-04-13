using Journal.Domain.Result;

namespace Journal.Domain.Abstractions.Validations
{
    public interface IBaseValidator <in T> where T : class
    {
        BaseResult ValidateOnNull(T obj);
    }
}
