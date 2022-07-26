using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimeCop.TimeSheet.Data;
using TimeCop.TimeSheet.Services;

namespace TimeCop.Web.Areas.Admin.Pages.BankHolidays;

public class IndexModel : PageModel
{

    private readonly IBankHolidayService _bankHolidayService;

    public IndexModel(IBankHolidayService bankHolidayService)
    {
        _bankHolidayService = bankHolidayService;
    }

    public IList<BankHoliday> BankHolidays { get; set; }
    public void OnGet()
    {
        BankHolidays= _bankHolidayService.GetAll();
    }
}
