using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TimeCop.Identity;
using TimeCop.Identity.Models;

namespace TimeCop.Web.Areas.Admin.Pages.Users;

public class IndexModel : PageModel
{
    private readonly IUserService _userService;

    public IndexModel( IUserService userService)
    {
        _userService = userService;
    }

    public IList<UserItem> UserList { get; set; }
    public async Task<IActionResult> OnGet()
    {
        UserList = await _userService.FindAllAsync();
        return Page();
    }
}
