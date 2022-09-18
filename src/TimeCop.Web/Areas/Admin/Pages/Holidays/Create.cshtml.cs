using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimeCop.TimeSheet.Application;
using TimeCop.TimeSheet.Domain;
using TimeCop.TimeSheet.Models;

namespace TimeCop.Web.Areas.Admin.Pages.Holidays;

public class CreateModel : PageModel
{
    private readonly IHolidayService _holidayService;

    public CreateModel(IHolidayService holidayService)
    {
        _holidayService = holidayService;
    }

    [BindProperty]
    public HolidayInput Input { get; set; }
    public async Task<IActionResult> OnPost()
    {
        await _holidayService.Add(Input.Adapt<Holiday>());
        return RedirectToPage("./index");
    }
}

public class HolidayInput
{
    public DateTime Date { get; set; }
    public string Note { get; set; }

    public bool CanOvertime { get; set; }
    public int OverTimeLimit { get; set; }
    public int OverTimeRate { get; set; }
}
