using TimeCop.TimeSheet.Models;

namespace TimeCop.Identity;

public class UserItem // Data Transfer Object
{
    public string Id { get; init; } = default!;
    public string UserName { get; init; }= default!;

}

public interface IUserService
{
    Task<bool> CreateUser(string userName, string userEmail);
    Task<IList<UserItem>> FindAllAsync();

}