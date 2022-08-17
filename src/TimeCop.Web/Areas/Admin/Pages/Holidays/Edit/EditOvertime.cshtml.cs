using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TimeCop.TimeSheet.Application;

namespace TimeCop.Web.Areas.Admin.Pages.Holidays.Edit;

public class EditOvertimeModel : PageModel
{
    private readonly HolidayService _holidayService;

    public class OvertimeInputViewModel
    {
        public int Id { get; set; }


        public bool CanOvertime { get; set; }

        [Range(0,300)]
        public int OverTimeLimit { get; set; }

        [Range(1, 3)]
        public int OverTimeRate { get; set; }
    }

    public EditOvertimeModel(HolidayService holidayService)
    {
        _holidayService = holidayService;
    }

    public async Task<IActionResult> OnGet(int holidayId)
    {
        var holiday = await _holidayService.GetAsync(holidayId);
        return Page();
    }

    [BindProperty]
    public OvertimeInputViewModel Input { get; set; }
    public async Task<IActionResult> OnPost()
    {
        await _holidayService.UpdateOvertime(Input.Adapt<OvertimeInput>());
        return RedirectToPage("./index");
    }
}
