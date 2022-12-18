using System.ComponentModel.DataAnnotations;

namespace TimeCop.Identity;

public class UserItem 
{
    public string Id { get; init; } = default!;
    public string UserName { get; init; } = default!;
    public string Email { get; set; } = default!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int StaffId { get; set; }

}

public interface IUserService
{
    Task<bool> CreateUser(int staffId, string userName, string userEmail, string password);
    Task<IList<UserItem>> FindAllAsync();
    Task<UserItem> FindAsync(string userId);
    Task UpdateAsync(UserItem userItem);
}