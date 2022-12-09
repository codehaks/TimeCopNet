using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NodaTime;
using NodaTime.Extensions;
using TimeCop.TimeSheet.Services;

namespace TimeCop.Web.Areas.Admin.Pages.BankHolidays;

[BindProperties]
public class CreateModel : PageModel
{
    private readonly IBankHolidayService _bankHolidayService;

    public CreateModel(IBankHolidayService bankHolidayService)
    {
        _bankHolidayService = bankHolidayService;
    }

    public string Name { get; set; }
    public DateOnly Date { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Input Validation

        if (ModelState.IsValid == false)
        {
            return Page();
        }

        // Run inside operation
        await _bankHolidayService.Create(Date.ToLocalDate(), Name);

        return RedirectToAction("./Index");
    }
}
