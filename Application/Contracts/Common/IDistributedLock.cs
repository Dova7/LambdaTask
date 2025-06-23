namespace Application.Contracts.Common
{
    public interface IDistributedLock
    {
        Task RunLockedAsync(long key, Func<Task> action);
    }
}
