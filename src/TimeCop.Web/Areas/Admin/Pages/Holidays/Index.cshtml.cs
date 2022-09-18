using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimeCop.TimeSheet.Application;
using TimeCop.TimeSheet.Models;

namespace TimeCop.Web.Areas.Admin.Pages.Holidays;

public class IndexModel : PageModel
{
    private readonly IHolidayService _holidayService;

    public IndexModel(IHolidayService holidayService)
    {
        _holidayService = holidayService;
    }

    public IList<HolidayReadData> HolidayList { get; set; }

    public async Task OnGetAsync()
    {
        HolidayList = await _holidayService.GetAll();
    }
}
