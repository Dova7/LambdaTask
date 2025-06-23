namespace Application.Contracts.IServices.Identity
{
    public interface ICurrentUserService
    {
        Task<Guid> GetUserIdAsync();  
        Task<string> GetUserNameAsync();
        Task<IEnumerable<string>> GetUserRolesAsync();
    }
}
