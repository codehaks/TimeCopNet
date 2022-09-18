using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimeCop.TimeSheet.Domain;

namespace TimeCop.Web.Areas.Admin.Pages.Holidays.Edit;

public class EditHolidayModel : PageModel
{
    public void OnGet(int holidayId)
    {
        var id = new HolidayId(holidayId);


        // GetHoliday
    }
}
