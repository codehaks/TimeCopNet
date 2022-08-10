using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeCop.Identity.Models;

namespace TimeCop.Identity;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> CreateUser(string userName, string userEmail)
    {
        var user = new ApplicationUser { UserName = userName, Email = userEmail };
        var result = await _userManager.CreateAsync(user);
        return result.Succeeded;
    }

    public async Task<IList<UserItem>> FindAllAsync()
    {
        var users = _userManager.Users.ProjectToType<UserItem>();
        return await users.ToListAsync();
    }

    public async Task<UserItem> FindAsync(string userId)
    {
        return await _userManager
             .Users.ProjectToType<UserItem>().FirstAsync(u => u.Id == userId);
    }

    public async Task UpdateAsync(UserItem userItem)
    {
        var user = await _userManager.FindByIdAsync(userItem.Id);
        user.Email = userItem.Email;
        await _userManager.UpdateAsync(user);
    }
}
