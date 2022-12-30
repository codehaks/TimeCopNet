using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NodaTime;
using TimeCop.Identity;
using TimeCop.TimeSheet.Domain.Models;
using TimeCop.TimeSheet.Infrastructure;

namespace TimeCop.Web.Areas.User.Pages.Sessions;

public class IndexModel : PageModel
{
    private readonly ISheetRepository _sheetRepository;
    private readonly IUserService _userService;

    public IndexModel(ISheetRepository sheetRepository, IUserService userService)
    {
        _sheetRepository = sheetRepository;
        _userService = userService;
    }

    public Sheet Sheet { get; set; }
    public async Task<IActionResult> OnGet()
    {
        var user = await _userService.FindAsync(User.GetUserId());
        Sheet = _sheetRepository.GetTimeSheetByStaffId(user.StaffId.ToString(),LocalDateTime.FromDateTime(DateTime.Now.Date), LocalDateTime.FromDateTime(DateTime.Now.Date));
        return Page();
    }
}
