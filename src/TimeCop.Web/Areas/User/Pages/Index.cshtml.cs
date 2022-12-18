using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TimeCop.Web.Areas.User.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public required string Note { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {

        return Page();
    }

}
