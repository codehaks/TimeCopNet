using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimeCop.Identity;

namespace TimeCop.Web.Areas.Admin.Pages.Users;

public class EditInput
{
    public string Id { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
}
public class EditModel : PageModel
{
    public IUserService _userService { get; set; }

    public EditModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    public EditInput Input { get; set; }
    public async Task<IActionResult> OnGet(string userId)
    {
        Input = (await _userService.FindAsync(userId)).Adapt<EditInput>();
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        await _userService.UpdateAsync(Input.Adapt<UserItem>());
        return RedirectToPage("./index");
    }
}
