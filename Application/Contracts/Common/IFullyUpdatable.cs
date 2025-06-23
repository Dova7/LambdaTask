namespace Application.Contracts.Common
{
    public interface IFullyUpdatable<T> where T : class
    {
        Task<T> UpdateAsync(T entity);
    }
}
