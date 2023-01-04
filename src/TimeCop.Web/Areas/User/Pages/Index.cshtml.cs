using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TimeCop.Identity;
using TimeCop.TimeSheet.Application.Services;
using TimeCop.TimeSheet.Domain.Models;
using TimeCop.TimeSheet.Services;

namespace TimeCop.Web.Areas.User.Pages;

public class IndexModel : PageModel
{
    private readonly ISessionService _sessionService;
    private readonly IUserService _userService;
    private readonly IStaffService _staffService;

    public IndexModel(ISessionService sessionService, IUserService userService, IStaffService staffService)
    {
        _sessionService = sessionService;
        _userService = userService;
        _staffService = staffService;
    }

    [BindProperty]
    public required string Note { get; set; }

    public Session Session { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var user = await _userService.FindAsync(User.GetUserId());
        Session = _sessionService.Get(user.StaffId);
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        var user = await _userService.FindAsync(User.GetUserId());
        var staff = _staffService.Get(user.StaffId);

        _sessionService.Create(new HourInput
        {
            Note = Note,
            StaffId = user.StaffId,
            StaffName = staff.FirstName + " " + staff.LastName
        });
        return RedirectToPage();
    }

}

public static class UserExtentions
{
    public static string GetUserId(this ClaimsPrincipal user)
    {
        if (user is not null && user.Identity is not null && user.Identity.IsAuthenticated)
        {
            var nameIdentifier = user.FindFirst(ClaimTypes.NameIdentifier);
            return (nameIdentifier?.Value ?? string.Empty);
        }
        return string.Empty;

    }
}