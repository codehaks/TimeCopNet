namespace TimeCop.Identity;

public class UserItem // Data Transfer Object
{
    public string Id { get; init; } = default!;
    public string UserName { get; init; } = default!;
    public string Email { get; set; } = default!;

}

public interface IUserService
{
    Task<bool> CreateUser(string userName, string userEmail, string password);
    Task<IList<UserItem>> FindAllAsync();
    Task<UserItem> FindAsync(string userId);
    Task UpdateAsync(UserItem userItem);
}