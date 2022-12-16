using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimeCop.TimeSheet.Data;
using TimeCop.TimeSheet.Services;

namespace TimeCop.Web.Areas.Admin.Pages.Staffs;

public class IndexModel : PageModel
{
    private readonly IStaffService _staffService;

    public IndexModel(IStaffService staffService)
    {
        Guard.Against.Null(staffService, nameof(staffService));
        _staffService = staffService;
    }
    public IList<Staff> StaffList { get; set; }
    public void OnGet()
    {
        StaffList = _staffService.GetAll();
    }
}
